using FMFX.PlaywrightSpecflow.Tests.Utilities;
using Microsoft.Playwright;

namespace FMFX.PlaywrightSpecflow.Tests.PageObjects.AdminPortal
{
    public class FundActivityPage
    {
        public IPage _page;
        public UIActionHelper _uiActionHelper;
        public string? transactionId;
        public string? transactionType;

        public FundActivityPage(IPage page, UIActionHelper uIActionHelper)
        {
            _page = page;
            _uiActionHelper = uIActionHelper;
        }


        public ILocator SearchUsingID => _page.Locator("(//div[@id='trasactionsGrid']/table//tr[@class='k-filter-row']/th)[1]//input[1]");
        public ILocator VerficationLink => _page.Locator($"//div[@id='trasactionsGrid']/table/tbody/tr/td[contains(text(),'{transactionId}')]/following-sibling::td[4][contains(text(),'{transactionType}')]/following-sibling::td[5]/a[text()='Verification details']");
        public ILocator TMInfoIcon => _page.Locator($"//div[@id='verificationDetailsPopup']//tbody//td/a[contains(text(),'{transactionId}')]/../following-sibling::td//span");
        public ILocator TMVerificationByTransactionId => _page.Locator($"//span[text()='Enquiry details']/../following-sibling::div//table/tbody/tr/td[text()='transactionID']/following-sibling::td");
        public ILocator BatchId => _page.Locator($"//div[@id='trasactionsGrid']/table/tbody/tr/td[contains(text(),'{transactionId}')]/following-sibling::td[1]");

    }
}
