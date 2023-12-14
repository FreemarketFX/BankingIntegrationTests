using Microsoft.Playwright;

namespace FMFX.PlaywrightSpecflow.Tests.PageObjects.AdminPortal
{
    public class ReviewPage
    {
        public IPage _page;

        public ReviewPage(IPage page)
        {
            _page = page;
        }

        public int index;
        public string? batchId;

        public ILocator ViewDetailsLink(string ID) => _page.Locator("//td[text()='" + ID + "']/..//td//a[text()='View Details']");
        public ILocator ApproveButtonOnViewDetailsForCount => _page.Locator("//div[@id='verificationDetailsPopup']/..//table//tbody/tr//button[text()='Approve']");//("//button[contains(@class,'btn-success') and (text()='Approve')]");
        public ILocator ApproveButtonOnViewDetails => _page.Locator($"(//div[@id='verificationDetailsPopup']/..//table//tbody)/tr[{index}]//button[text()='Approve']");
        public ILocator RejectButtonOnViewDetails => _page.Locator("//button[contains(@class, 'btn-danger')]");
        public ILocator ReasonForApprovalTextBox => _page.Locator("//label[text()='Reason for approval']//following-sibling::input[contains(@class, 'b-text-input-field')]");
        public ILocator ApproveButton => _page.Locator("//button[(@type='button') and (text()='Approve')]");
        public ILocator CloseWindowButton => _page.Locator("(//div[@class='k-window-actions']//a[@aria-label='Close'])[1]");
        public ILocator CheckBatchId => _page.Locator($"//td[text()='{batchId}']/preceding-sibling::td");
    }
}
