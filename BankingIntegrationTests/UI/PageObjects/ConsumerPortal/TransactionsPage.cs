using FMFX.PlaywrightSpecflow.Tests.Utilities;
using Microsoft.Playwright;

namespace FMFX.PlaywrightSpecflow.Tests.PageObjects.ConsumerPortal
{
    public class TransactionsPage
    {
        public IPage _page;
        public UIActionHelper _uiActionHelper;

        public TransactionsPage(IPage page, UIActionHelper uiActionHelper)
        {
            _page = page;
            _uiActionHelper = uiActionHelper;
        }

        public int rowNumber;
        public int index;
        public string transactionName = "";
        public string? AccountId, WithdrawalId, status;


        public ILocator TransactionStatusButton => _page.Locator($"//span[text()='{status}']");
        public ILocator ExchangeStatus => _page.Locator("//span[text()='Completed']");
        public ILocator transactionStatusHeading => _page.Locator($"//div[@id='groupedButtonsWrapper']//h1[@id='heading' and contains(text(),'{status}')]");
        public ILocator transactionTypeTransactionTableSelector => _page.Locator($"//div[@id='scheduledTrasactionsGrid']//tbody/tr[{rowNumber}]/td//div[text()='Transaction Type']/following-sibling::div//span[contains(text(), 'Real-time Exchange')]/../following-sibling::div/span[{index}]");
        public ILocator exchangeIDTransactionTableSelector => _page.Locator($"//div[@id='scheduledTrasactionsGrid']//tbody/tr[{rowNumber}]/td//div[text()='ID']/following-sibling::div/a");
        public ILocator transactionTypeNameSelector => _page.Locator($"//div[@id='scheduledTrasactionsGrid']//tbody/tr[{rowNumber}]/td//div[text()='Transaction Type']/following-sibling::div//span[contains(@class,'normal-text')]");

        public ILocator serviceFeeAmount => _page.Locator("//span[contains(text(),'Our service fee')]/../following-sibling::div");

        public ILocator WithdrawalTransactionIdLink => _page.Locator($"//a[(@href='/Customer/{AccountId}/Withdrawal/Detail?withdrawalId={WithdrawalId}') and (text()='View details')]");

        public ILocator WithdrawalAmountTransactionDetails => _page.Locator("//*[@id=\"transactionDetails\"]/div/fmfx-transaction-details/div[4]/div[2]/div/span[2]");
        public ILocator WithdrawalCurrencyTransactionDetails => _page.Locator("//*[@id=\"transactionDetails\"]/div/fmfx-transaction-details/div[4]/div[2]/div/strong");
        public ILocator WithdrawalStatusTransactionDetails => _page.Locator("//span[@data-bind='text: transaction().Status']");
        public ILocator WithdrawalIdAfterSubmission => _page.Locator("//span[text()='Withdrawal']/following-sibling::span");
        public ILocator withdrawalTransactionTableSelector => _page.Locator($"//div[@id='scheduledTrasactionsGrid']//tbody/tr[{rowNumber}]/td//div[text()='Transaction Type']/following-sibling::div//span[contains(text(), 'Withdrawal')]/../../following-sibling::div");
        public ILocator WithdrawalTransactionTableStatus => _page.Locator($"//div[@id='scheduledTrasactionsGrid']//tbody/tr[{rowNumber + 1}]/td//div[text()='Status']/following-sibling::div//span[text()='Completed']");

        public ILocator transactionId => _page.Locator($"//*[contains(text(),'{transactionName}')]/following-sibling::span[contains(text(),'ID')]");

        public ILocator transactionTypeFilter => _page.Locator("//div[@id='scheduledTrasactionsGrid']//span[contains(text(),'Transaction Type')]/following-sibling::span/span");

        public ILocator transactionIdFilter => _page.Locator("//div[@id='scheduledTrasactionsGrid']//a[@id='idFilter']");
        public ILocator transactionIdFilterInput => _page.Locator("//div[@id='idFilterPopup']//input[@id='idFilterPopupInput']");
        public ILocator transactionFilterButton => _page.Locator("//div[@id='idFilterPopup']//input[@id='idFilterPopupInput']/..//a[contains(text(),'Filter')]");


        public string transactionRef()
        {
            var id = _uiActionHelper.GetTextContent(transactionId);
            var txnid = id.Split(":").Last().Trim();
            return txnid;
        }

        public void SelectTransactionTypeFromFilter(string txnType)
        {
            try
            {
                _uiActionHelper.Click(transactionTypeFilter);
                var getAttributeValue = transactionTypeFilter.GetAttributeAsync("aria-activedescendant").GetAwaiter().GetResult();
                ILocator type = _page.Locator($"//li[@id='{getAttributeValue}']/../li[text()='{txnType}']");
                _uiActionHelper.Click(type);
            }
            catch (Exception e)
            {
                throw new Exception("Error occurred :" + e.Message);
            }
        }

        public void FilterByTransactionId(string id)
        {
            _uiActionHelper.Click(transactionIdFilter);
            _uiActionHelper.Fill(transactionIdFilterInput, id);
            _uiActionHelper.Click(transactionFilterButton);
        }

    }
}
