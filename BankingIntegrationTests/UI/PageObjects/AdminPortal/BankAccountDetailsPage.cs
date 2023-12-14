using FMFX.PlaywrightSpecflow.Tests.Utilities;
using Microsoft.Playwright;

namespace FMFX.PlaywrightSpecflow.Tests.PageObjects.AdminPortal
{
    public class BankAccountDetailsPage
    {
        public IPage _page;
        public UIActionHelper _uiActionHelper;

        public string? PaymentNumber;
        public string? tabText;

        public BankAccountDetailsPage(IPage page, UIActionHelper uIActionHelper)
        {
            _page = page;
            _uiActionHelper = uIActionHelper;
        }

        public ILocator DepositId => _page.Locator("(//td[@data-bind='text: CashflowId'])[1]");
        public ILocator DepositReference => _page.Locator("(//span[@data-bind='text: Reference'])[1]");
        public ILocator DepositMoneyIn => _page.Locator("(//td[contains(@data-bind,'MoneyIn')])[1]");
        public ILocator ReconcileButton => _page.Locator("(//a[text()='Reconcile'])[1]");
        public ILocator ChooseDepositorTypeHeader => _page.Locator("//confirm-header[text()='Choose depositor type']");
        public ILocator YesButton => _page.Locator("//a[text()='Yes']");
        public ILocator NoButton => _page.Locator("//a[text()='No']");
        public ILocator SaveButton => _page.Locator("//button[text()='Save']");
        public ILocator UnreconciledPaymentsLink => _page.Locator("//span[contains(text(),'Unreconciled payments')]");
        public ILocator CreateCashflowLink => _page.Locator($"//a[(contains(@href,'paymentId={PaymentNumber}')) and (text()='Create Cashflow')]");
        public ILocator tabLinks => _page.Locator($"//li[@role='tab']//span[contains(text(),'{tabText}')]");
    }
}
