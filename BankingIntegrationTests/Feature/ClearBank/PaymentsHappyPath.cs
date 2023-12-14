using BankingIntegrationTests.Fixture;
using BankingIntegrationTests.UI.Functions;
using FluentAssertions;
using Freemarket.BankIntegrationTests.UI.Functions;
using Freemarket.Test.Utilities.BankingCommon.Messages;
using Freemarket.Test.Utilities.Drivers;
using Freemarket.Test.Utilities.UI;
using Xunit.Abstractions;

namespace BankingIntegrationTests.Feature.ClearBank;

public  class PaymentsHappyPath : BankingIntegrationTestFixture
{
    private readonly BankingIntegrationTestFixture _fixture;
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly UIActionHelper _uiActionHelper;
    private readonly Driver _driver;


    public PaymentsHappyPath(BankingIntegrationTestFixture fixture, ITestOutputHelper testOutputHelper, UIActionHelper uIActionHelper, Driver driver)
    {
        _fixture = fixture;
        _fixture.Banking.ServiceBusUtility.OutputHelper = testOutputHelper;
        _testOutputHelper = testOutputHelper;
        _uiActionHelper = uIActionHelper;
        _driver = driver;
    }

    [Fact]
    public async Task VerfiyClearbankEURPaymentSettlesSuccessfully()
    {
        Login login = new Login(_uiActionHelper, _driver);
        login.LoginToPortal("", "");

        Withdrawal withdrawal = new Withdrawal(_uiActionHelper, _driver);
        withdrawal.GoToBalancesPage();
        withdrawal.SelectCurrencyAndAmount("GBP", 10.99m);
        withdrawal.SelectUltimateOrginator("TestClearBankCompany");
        string requestReference = withdrawal.SelectBeneficiary("test bene GBP", "Paying overseas suppliers");
        string withdrawalId = withdrawal.GetWithdrawalId();

        ProcessPayment processPayment = new ProcessPayment(_uiActionHelper, _driver);
        processPayment.GoToPaymentInAdmin("Clearbank GBP Account");
        processPayment.SelectAndSendPaymentToBank(withdrawalId);
        processPayment.CheckForWithdrawalStatus("Completed");

        var initiatePaymentsCommand = await _fixture.Banking.PollForEventByRequestReference<InitiatePaymentsCommandMessage>(requestReference);

        var endToEndId = initiatePaymentsCommand.Payments[0].EndToEndId;
        _testOutputHelper.WriteLine("EndToEndId: {0}", endToEndId);

        //assert
        var paymentInitiatedEvent =
          await _fixture.Banking.PollForEventByRequestReference<PaymentInitiatedEventMessage>(endToEndId);

        var paymentNumber = paymentInitiatedEvent.RequestReference;

        // assert
        var (_, paymentRequestedEvent) =
            await _fixture.Banking.PollForEventsByPaymentNumber<PaymentRequestFailedEventMessage, PaymentRequestedEventMessage>(paymentNumber!);

        paymentRequestedEvent.Should().NotBeNull();
        paymentRequestedEvent?.PaymentNumber.Should().Be(paymentNumber);

        //validate the request sent to clearbank in Cosmos DB

        //validate webhhok received from clearbank in Cosmos DB

        //verify payment settled event
        //verify paymentCompleted event
        //verify transaction created event
        //verify cashflow created and reconciled in core

        
    }

}
