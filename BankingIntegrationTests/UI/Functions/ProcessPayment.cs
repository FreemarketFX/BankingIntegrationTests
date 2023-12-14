using FMFX.PlaywrightSpecflow.Tests.PageObjects.AdminPortal;
using Freemarket.Test.Utilities.Drivers;
using Freemarket.Test.Utilities.UI;

namespace Freemarket.BankIntegrationTests.UI.Functions
{
    public class ProcessPayment
    {
        private readonly UIActionHelper _uiActionHelper;
        private readonly AdminBasePage _adminBasePage;
        private readonly BankingPage _bankingPage;
        private readonly MakePaymentsPage _makePaymentsPage;
        private readonly Driver _driver;

        public ProcessPayment(UIActionHelper uIActionHelper, Driver driver)
        {
            _uiActionHelper = uIActionHelper;
            _driver = driver;
            _adminBasePage = new AdminBasePage(driver.Page, _uiActionHelper);
        }

        public void GoToPaymentInAdmin(string accountName)
        {
            _uiActionHelper.Click(_adminBasePage.GetAdminPageLink("Banking"));
            _uiActionHelper.Click(_bankingPage.InputBankName);
            _uiActionHelper.EnterText(_bankingPage.InputBankName, accountName);
            _bankingPage.BankAccountName = accountName;
            _uiActionHelper.Click(_bankingPage.BankName);
            _uiActionHelper.Click(_bankingPage.LinkMakePayments);
        }

        public void SelectAndSendPaymentToBank(string withdrwalId)
        {
            _uiActionHelper.WaitAndClick(_makePaymentsPage.IdSorting);
            _makePaymentsPage.WithdrawalId = withdrwalId;
            if (_uiActionHelper.IsVisible(_makePaymentsPage.WithdrawalCheckbox))
            {
                _uiActionHelper.Click(_makePaymentsPage.WithdrawalCheckbox);
            }
            _makePaymentsPage.ShouldAcceptTheConfirmPrompts().GetAwaiter().GetResult();
            _uiActionHelper.Click(_makePaymentsPage.MakePaymentButton);
            var paymentNumber = _uiActionHelper.GetTextContent(_makePaymentsPage.PaymentNumberOnPaymentBatchProcessingWindow).Replace("#", "").Trim();
            _uiActionHelper.Click(_makePaymentsPage.SendButtonOnPaymentBatchProcessingWindow);
        }

        public void CheckForWithdrawalStatus(string status)
        {

        }



    }
}
