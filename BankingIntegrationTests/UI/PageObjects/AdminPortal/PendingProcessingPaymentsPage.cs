using Freemarket.Test.Utilities.UI;
using Microsoft.Playwright;

namespace FMFX.PlaywrightSpecflow.Tests.PageObjects.AdminPortal
{
    public class PendingProcessingPaymentsPage
    {

        public IPage _page;
        public UIActionHelper _uiActionHelper;

        public string? DepositorDropDownValue;
        public string? intermediateOptionText;

        public PendingProcessingPaymentsPage(IPage page, UIActionHelper uIActionHelper)
        {
            _page = page;
            _uiActionHelper = uIActionHelper;
        }

        public string WithdrawalID = "";

        public ILocator WithdrawalCancelButton => _page.Locator($"//*[@id='processingPaymentsGrid']//td[text()='W{WithdrawalID}']//following-sibling::td//div//button");
        public ILocator WithdrawalInPaymentCancellations => _page.Locator($"*//td[contains(text(),'{WithdrawalID}')]");

        public ILocator ReasonForCancellation => _page.Locator("//label[text()='Reason']//following-sibling::textarea");
        public ILocator WithdrawalInPaymentCancellationViewDetials => _page.Locator($"*//td[contains(text(),'{WithdrawalID}')]//..//button[contains(text(),'View Details')]");
    }
}
