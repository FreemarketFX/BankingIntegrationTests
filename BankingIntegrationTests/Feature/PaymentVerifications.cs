using BankingIntegrationTests.Fixture;
using FluentAssertions;
using Freemarket.Test.Utilities.BankingCommon.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace Freemarket.BankIntegrationTests.Feature
{
    public class PaymentVerifications : BankingIntegrationTestFixture
    {
        private readonly BankingIntegrationTestFixture _fixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public PaymentVerifications(BankingIntegrationTestFixture fixture, ITestOutputHelper testOutputHelper)
        {
            _fixture = fixture;
            _testOutputHelper = testOutputHelper;
        }

        public async Task VerifyPaymentInitiatedEvent(InitiatePaymentsCommandMessage initiatePaymentCommand, PaymentInitiatedEventMessage paymentInitiatedEvent)
        {
            paymentInitiatedEvent.Should().NotBeNull();
            paymentInitiatedEvent.Should().BeEquivalentTo(new PaymentInitiatedEventMessage
            {
                BankId = 7,
                RequestReference = initiatePaymentCommand.Payments[0].EndToEndId,
                SenderIban = initiatePaymentCommand.Payments[0].DebtorAccount.Iban,
                SendingAmount = initiatePaymentCommand.Payments[0].Amount,
                TargetAmount = initiatePaymentCommand.Payments[0].Amount,
                Currency = initiatePaymentCommand.Payments[0].CurrencyCode,
                TargetCurrency = initiatePaymentCommand.Payments[0].TargetCurrencyCode,
                ReceiverName = initiatePaymentCommand.Payments[0].CreditorName,
                ReceiverIban = initiatePaymentCommand.Payments[0].CreditorAccount.Iban,
                ReceiverAccountNumber = initiatePaymentCommand.Payments[0].CreditorAccount.AccountNumber,
                ReceiverBankMemberId = initiatePaymentCommand.Payments[0].CreditorAgent.MemberId,
                ReceiverSortCode = initiatePaymentCommand.Payments[0].CreditorAgent.MemberId,
                ReceiverBankBic = initiatePaymentCommand.Payments[0].CreditorAgent.Bic,
                ReceiverBankCountryCode = initiatePaymentCommand.Payments[0].CreditorAgent.CountryCode,
                ReceiverStreetName = initiatePaymentCommand.Payments[0].CreditorAddress.StreetName,
                ReceiverBuildingNumber = initiatePaymentCommand.Payments[0].CreditorAddress.BuildingNumber,
                ReceiverBuildingName = initiatePaymentCommand.Payments[0].CreditorAddress.BuildingName,
                ReceiverPostbox = initiatePaymentCommand.Payments[0].CreditorAddress.PostBox,
                ReceiverTownName = initiatePaymentCommand.Payments[0].CreditorAddress.TownName,
                ReceiverCountrySubDivision = initiatePaymentCommand.Payments[0].CreditorAddress.CountrySubDivision,
                ReceiverPostCode = initiatePaymentCommand.Payments[0].CreditorAddress.PostCode,
                ReceiverTownLocationName = initiatePaymentCommand.Payments[0].CreditorAddress.TownLocationName,
                ReceiverCountryCode = initiatePaymentCommand.Payments[0].CreditorAddress.CountryCode,
                UltimateDebtorName = initiatePaymentCommand.Payments[0].UltimateDebtorName,
                UltimateDebtorBuildingNumber = initiatePaymentCommand.Payments[0].UltimateDebtorAddress.BuildingNumber,
                UltimateDebtorBuildingName = initiatePaymentCommand.Payments[0].UltimateDebtorAddress.BuildingName,
                UltimateDebtorStreetName = initiatePaymentCommand.Payments[0].UltimateDebtorAddress.StreetName,
                UltimateDebtorTownName = initiatePaymentCommand.Payments[0].UltimateDebtorAddress.TownName,
                UltimateDebtorPostbox = initiatePaymentCommand.Payments[0].UltimateDebtorAddress.PostBox,
                UltimateDebtorTownLocationName = initiatePaymentCommand.Payments[0].UltimateDebtorAddress.TownLocationName,
                UltimateDebtorCountrySubDivision = initiatePaymentCommand.Payments[0].UltimateDebtorAddress.CountrySubDivision,
                UltimateDebtorPostCode = initiatePaymentCommand.Payments[0].UltimateDebtorAddress.PostCode,
                UltimateDebtorCountryCode = initiatePaymentCommand.Payments[0].UltimateDebtorAddress.CountryCode,
                UltimateDebtorAccountNumber = initiatePaymentCommand.Payments[0].UltimateDebtorAccountId,
                MessageForReceiver = initiatePaymentCommand.Payments[0].Reference,
                Reference = initiatePaymentCommand.Payments[0].Reference,
                PurposeCode = initiatePaymentCommand.Payments[0].PurposeCode,
                PurposeDescription = initiatePaymentCommand.Payments[0].PurposeDescription,
                BeneficiaryType = initiatePaymentCommand.Payments[0].BeneficiaryType,
                IntermediaryBankName = null,
                IntermediaryBankBic = null,
                IntermediaryBankCountryCode = null,
                ChargeBearer = null,
                DebtorName = initiatePaymentCommand.Payments[0].DebtorName,
                DebtorBuildingNumber = initiatePaymentCommand.Payments[0].DebtorAddress.BuildingNumber,
                DebtorBuildingName = initiatePaymentCommand.Payments[0].DebtorAddress.BuildingName,
                DebtorStreetName = initiatePaymentCommand.Payments[0].DebtorAddress.StreetName,
                DebtorTownName = initiatePaymentCommand.Payments[0].DebtorAddress.TownName,
                DebtorCountrySubDivision = initiatePaymentCommand.Payments[0].DebtorAddress.CountrySubDivision,
                DebtorPostbox = initiatePaymentCommand.Payments[0].DebtorAddress.PostBox,
                DebtorTownLocationName = initiatePaymentCommand.Payments[0].DebtorAddress.TownLocationName,
                DebtorPostCode = initiatePaymentCommand.Payments[0].DebtorAddress.PostCode,
                DebtorCountryCode = initiatePaymentCommand.Payments[0].DebtorAddress.CountryCode,
                RemittanceInformation = initiatePaymentCommand.Payments[0].RemittanceInformation,
                IsSepaReachable = initiatePaymentCommand.Payments[0].IsSepaReachable,
            }, options => options.Excluding(prf => prf.Id));
        }


    }
}
