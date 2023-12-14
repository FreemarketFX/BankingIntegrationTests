using FMFX.PlaywrightSpecflow.Tests.Utilities;
using Microsoft.Playwright;

namespace FMFX.PlaywrightSpecflow.Tests.PageObjects.AdminPortal
{
    public class MakePaymentsPage
    {
        public IPage _page;
        public UIActionHelper _uiActionHelper;
        public string? WithdrawalId;

        public MakePaymentsPage(IPage page, UIActionHelper uIActionHelper)
        {
            _page = page;
            _uiActionHelper = uIActionHelper;
        }

        public ILocator Id => _page.Locator("(//span[@data-field='Id']//input[@title='Id'])[1]");
        public ILocator WithdrawalCheckbox => _page.Locator($"//input[@id='{WithdrawalId}' and @type='checkbox']");
        public ILocator MakePaymentButton => _page.Locator("//button[@onclick='modelGeneratePayments()']");
        public ILocator PaymentBatchProcessingWindow => _page.Locator("//span[@id='paymentBatchProcessingWindow_wnd_title']//following-sibling::div//a[@aria-label='Close']");
        public ILocator PaymentNumberOnPaymentBatchProcessingWindow => _page.Locator($"//div[@id='paymentBatchProcessingWindow']//td[text()='{WithdrawalId}']//following-sibling::td[1]");
        public ILocator BeneficiaryIbanForWithdrawal => _page.Locator($"//td[text()='{WithdrawalId}']//following-sibling::td[4]//small//span[text()='IBAN:']//following-sibling::strong");
        public ILocator IdSorting => _page.Locator("//div[@id='makePayments']//div[@id='grid']//table//tr/th[@data-title='Id']/a/span");
        public ILocator SendButtonOnPaymentBatchProcessingWindow => _page.Locator("//button[@class='btn btn-success'][text()='Send']");
        public ILocator DownloadButtonOnPaymentBatchProcessingWindow => _page.Locator("//button[@class='btn btn-success'][text()='Download']");
        public ILocator PaymentStatusOnPaymentBatchProcessingWindow => _page.Locator($"//div[@id='paymentBatchProcessingWindow']//td[text()='{WithdrawalId}']//following::td[2]");
        public ILocator IbanOnMakePaymentsTable => _page.Locator($"//td[text()='{WithdrawalId}']//following::td[4]//small//span[text()='IBAN:']//following-sibling::strong");

        public async Task ShouldAcceptTheConfirmPrompts()
        {
            _page.Dialog += async (_, e) =>
            {
                await e.AcceptAsync();
            };

            bool result = await _page.EvaluateAsync<bool>("confirm('boolean?')");
            Assert.True(result);
        }

    }
}
