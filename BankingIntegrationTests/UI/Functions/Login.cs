using FMFX.UI.PageObjects.ConsumerPortal;
using Freemarket.Test.Utilities.Drivers;
using Freemarket.Test.Utilities.UI;
using OtpNet;
using System.Security.Policy;

namespace BankingIntegrationTests.UI.Functions
{
    public class Login
    {
        private readonly UIActionHelper _uiActionHelper;
        private readonly LoginPage _loginPage;
        private readonly Driver _driver;

        public Login(UIActionHelper uIActionHelper, Driver driver)
        {
            _driver = driver;
            _uiActionHelper = uIActionHelper;
            _loginPage = new LoginPage(_driver.Page, _uiActionHelper);
        }
        public void LoginToPortal(string username, string password)
        {
            _uiActionHelper.GoToUrl("url");

            if (_uiActionHelper.IsVisible(_loginPage.BtnAcceptAllCookies))
            {
                _uiActionHelper.Click(_loginPage.BtnAcceptAllCookies);
            }

            _uiActionHelper.EnterText(_loginPage.TxtEmail, username);
            _uiActionHelper.EnterText(_loginPage.TxtPassword, password);
            _uiActionHelper.Click(_loginPage.BtnLogin);

            _uiActionHelper.Fill(_loginPage.VerificationCode, GenerateTwoFactorAuthCode("usersecret"));
            _uiActionHelper.Click(_loginPage.VerifyButton);
        }

        //2FA code generation - MSA
        private string GenerateTwoFactorAuthCode(string secret)
        {
            Totp totp = new(secretKey: Base32Encoding.ToBytes(secret));
            return totp.ComputeTotp();
        }
    }
}
