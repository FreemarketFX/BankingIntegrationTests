using Freemarket.Test.Utilities.UI;
using Microsoft.Playwright;

namespace FMFX.PlaywrightSpecflow.Tests.PageObjects.AdminPortal
{
    public class AdminBasePage
    {
        private readonly IPage _page;
        private readonly UIActionHelper _uiActionHelper;

        public AdminBasePage(IPage page, UIActionHelper uIActionHelper)
        {
            _page = page;
            _uiActionHelper = uIActionHelper;
        }

        public ILocator LnkAdminPageSelector => _page.Locator("//ul[@id='mainNavigation']/li/a[text()='Customers']");
        public ILocator SignOut => _page.Locator("//ul[contains(@class,'header-menu')]//a[text()='Sign out']");
        public ILocator CustomerArea => _page.Locator("//a[contains(text(),'Customer Area')]");
        public ILocator AccountGrid => _page.Locator("#accountsGridWrapper");
        public ILocator AdminMenu => _page.Locator("#mainNavigation");

        public ILocator GetAdminPageLink(string linkName)
        {
            string pageSelector = $"//ul[@id='mainNavigation']/li/a[text()='{linkName}']";
            return _uiActionHelper.GetElement(pageSelector);
        }
    }
}