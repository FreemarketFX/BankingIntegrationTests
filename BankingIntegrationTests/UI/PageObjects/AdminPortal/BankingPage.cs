using FMFX.PlaywrightSpecflow.Tests.Utilities;
using Microsoft.Playwright;

namespace FMFX.PlaywrightSpecflow.Tests.PageObjects.AdminPortal
{
    public class BankingPage
    {
        public IPage _page;
        public UIActionHelper _uiActionHelper;
        public string? BankAccountName;

        public BankingPage(IPage page, UIActionHelper uIActionHelper)
        {
            _page = page;
            _uiActionHelper = uIActionHelper;
        }

        public ILocator InputBankName => _page.Locator($"//input[@aria-label='Account name']");
        public ILocator BankName => _page.Locator($"//a[text()='{BankAccountName}']");
        public ILocator LinkMakePayments => _page.Locator($"//a[text()='Make payments']");
        public ILocator LinkAddCashflow => _page.Locator($"//a[text()='Add cashflow']");


    }
}
