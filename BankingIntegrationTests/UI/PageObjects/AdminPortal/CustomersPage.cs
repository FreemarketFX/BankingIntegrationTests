using FMFX.PlaywrightSpecflow.Tests.Utilities;
using Microsoft.Playwright;

namespace FMFX.PlaywrightSpecflow.Tests.PageObjects.Admin
{
    public class CustomersPage
    {
        public IPage _page;
        public UIActionHelper _uiActionHelper;
        public string? custID;
        public string? menu;

        public CustomersPage(IPage page, UIActionHelper uIActionHelper)
        {
            _page = page;
            _uiActionHelper = uIActionHelper;
        }

        public string LnkNewAccountSelector = "xpath=//a[text()='New']";

        public ILocator AccountNumberTextBox => _page.Locator("//input[@aria-label='Account Number']");
        public ILocator AccountNumberLink => _page.Locator($"//a[text()='{custID}']");
        public ILocator AccountMenuOptions => _page.Locator($"//div[@id='tabstrip']//li/span[contains(text(),'{menu}')]");

        public string InputAccountNumberSearch = "xpath=//span/input[@aria-label='Account Number']";

        public void EnterAccountNumberForSearch(string accountNumber)
        {
            ILocator accountIdSearchbox = _uiActionHelper.GetElement(InputAccountNumberSearch);
            _uiActionHelper.EnterText(accountIdSearchbox, accountNumber);
            _uiActionHelper.PressKey(accountIdSearchbox, "Enter");
        }

        public void ClickOnAccountNumber(string accountNumber)
        {
            _uiActionHelper.Click(_uiActionHelper.GetElement($"//td/a[text()='{accountNumber}']"));
        }

        public void GoToDetailsTab(string tabName)
        {
            string tabselector = $"//div[@id='tabstrip']/ul/li/span[text()='{tabName}']";
            _uiActionHelper.Click(_uiActionHelper.GetElement(tabselector));
        }
    }
}
