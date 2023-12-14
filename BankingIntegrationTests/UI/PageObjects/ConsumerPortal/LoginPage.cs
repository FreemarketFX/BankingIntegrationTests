using Freemarket.Test.Utilities.UI;
using Microsoft.Playwright;

namespace FMFX.UI.PageObjects.ConsumerPortal
{
    public class LoginPage
    {
        private readonly IPage _page;
        private readonly UIActionHelper _uiActionHelper;

        public LoginPage(IPage page, UIActionHelper uiActionHelper)
        {
            _page = page;
            _uiActionHelper = uiActionHelper;
        }

        public ILocator LnkLogin => _page.Locator("//a[@href='/User/LogIn']");//("text=Login");
        public ILocator TxtEmail => _page.Locator("#Username");//_page.Locator("#Email");
        public ILocator Email => _page.Locator("#Username");
        public ILocator oldLogin => _page.Locator("#subscribe");

        public ILocator TxtPassword => _page.Locator("#Password");
        public ILocator ConfirmPassword => _page.Locator("#ConfirmPassword");
        public ILocator SetPassword => _page.Locator("//button[text()='Set my password']");
        public ILocator BackToLogin => _page.Locator("//*[text()='Back to login']");
        public ILocator BtnLogin => _page.Locator("//div[@class='login-page']//button[@value='login']");
        public ILocator EmailVerificationConfirmation => _page.Locator("//h5[contains(text(),'Your email is now verified')]");
        public ILocator BtnAcceptAllCookies => _page.Locator("//span/a[@id='acceptCookiesButton']");
        public ILocator RegistrationCookie => _page.Locator("/div[@id='cookieConsentBanner']/div//a[contains(text(),'Accept')]");
        public ILocator DismissCookieMsg => _page.Locator("//div[@class='cc-compliance']//a[contains(@class,'cc-dismiss')]");
        public ILocator BtnSettings => _page.Locator("span.fxicons.fxicon-settings.item-value.b-readonly-field__icon");
        public ILocator BtnSignOut => _page.Locator("a[class='b-sign-out-panel__item-link']");
        public ILocator BtnAdminSignOut => _page.Locator("//a[@href='/User/logoff']");
        public ILocator LoginRedirect => _page.Locator("//div[contains(@class,'logged-out-container')]//a[@class='PostLogoutRedirectUri']");

        public ILocator VerificationCode => _page.Locator("#TwoFactorCode");
        public ILocator VerifyButton => _page.Locator("//button[text()='Log in']");
        public async Task ClickLogin() => await LnkLogin.ClickAsync();


    }
}
