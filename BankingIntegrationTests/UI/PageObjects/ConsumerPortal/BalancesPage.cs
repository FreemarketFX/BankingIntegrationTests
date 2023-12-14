using Freemarket.Test.Utilities.UI;
using Microsoft.Playwright;

namespace FMFX.UI.PageObjects.ConsumerPortal
{
    public class BalancesPage
    {
        public IPage _page;
        private UIActionHelper _uiactionHelper;

        public BalancesPage(IPage page, UIActionHelper uIActionHelper)
        {
            _page = page;
            _uiactionHelper = uIActionHelper;
        }
        public string balancesCurrency = "";

        public ILocator BalanceAmount => _page.Locator($"//a[@id='{balancesCurrency}']//span[2]");
        public ILocator WithdrawFunds => _page.Locator("//a[text()='Withdraw funds']");
        public ILocator BalanceAmountText => _page.Locator($"a[id={balancesCurrency}] span[class=b-text-with-flag__text]");
        public ILocator ContinueButton => _page.Locator("//button[@id='continue']");


        public ILocator GetCurrencyLink(string currency)
        {
            string locator = $"//a[@id='{balancesCurrency}']";
            return _uiactionHelper.GetElement(locator);
        }
    }
}
