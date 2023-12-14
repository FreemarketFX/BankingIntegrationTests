using Microsoft.Playwright;

namespace FMFX.UI.PageObjects.ConsumerPortal
{
    public class DashboardPage
    {
        private readonly IPage _page;

        public DashboardPage(IPage page)
        {
            _page = page;
        }

        public string menu = "";
        public string dashboardButton = "";
        public string navigationBarButtonChoice = "";
        public string transactionID = "", transferorDetail = "", transferorOption = "", transferorType = "", transferorCountry = "", verticalValue = "", industryValue = "";

        public string PageNameSelector => $"//*[@class='b-nav']/following-sibling::main//h1";
        public string DashboardNavigationLinkSelector => $"//*[@class='row b-nav-content v-aligned-container']//*[contains(text(),'{dashboardButton}')]";
        public string DashboardNavigationButtonSelector => $"//*[@class='row b-nav-content v-aligned-container']//*[contains(text(),'New exchange')]//../..//*[contains(text(),'{dashboardButton}')]";
        public string NewExchangeButton(string custID) => "div > a[href='/Customer/" + custID + "/Instructions/Add'] > span";
        public string BankTransferButton(string custID) => "div > a[href='/Customer/" + custID + "/Deposit/Add'] > span";
        public string NavigationBarButtonBy => $"//ul[@id='mainNavigation']/li/a[contains(text(),'{navigationBarButtonChoice}')]";
        public string UploadDocumentButtonBy => "//input[@id='pendingDepositFile']";
        public string AccountNumberData => "//*[contains(@class,'activeAccount')]/span[@id='activeAccountIcon']/following-sibling::div";
        public ILocator PageName => _page.Locator(PageNameSelector);
        public ILocator DashboardNavigationLink => _page.Locator(DashboardNavigationLinkSelector);
        public ILocator DashboardNavigationButton => _page.Locator(DashboardNavigationButtonSelector);
        public ILocator NavigationBarButton => _page.Locator(NavigationBarButtonBy);
        public ILocator AccountNumber => _page.Locator(AccountNumberData);
        public ILocator NewExchangeButtonClick(string ID) => _page.Locator(NewExchangeButton(ID));
        public ILocator BankTransferButtonClick(string ID) => _page.Locator(BankTransferButton(ID));
        public ILocator LinkBalances => _page.Locator("//a[text()='Balances']");
        public ILocator BankTransferStatus => _page.Locator($"//div[@id='pendingDepositsWidget']//table/tbody/tr/td//div[text()='ID']/following-sibling::div/div[text()='{transactionID}']/../../../following-sibling::td[4]/div");//($"(//div[text()='{transactionID}']//following::td[@class='b-grid__column']//span)[2]");
        public ILocator PendingBankTransferStatus => _page.Locator($"//div[text()='{transactionID}']//ancestor::tr//td[1]//div[@class='b-grid__column-content']//div[1]");
        public ILocator AddTransferorInfoLink => _page.Locator($"//div[text()='{transactionID}']//following::a[text()='Add transferor info']");
        public ILocator AddTransferorInfoModalBoxHeader => _page.Locator("//confirm-header[text()='Add Transferor Info']");
        public ILocator ButtonOnAddTransferorInfoModal => _page.Locator($"//div[@id='addDepositorPopup']//span[contains(text(), '{transferorOption}')]");
        public ILocator IndividualTransferorOnAddTransferorInfoModal => _page.Locator("//a[contains(@data-bind,'selectIsIndividual')]//span[contains(text(), 'Individual')]");
        public ILocator CompanyTransferorOnAddTransferorInfoModal => _page.Locator("//a[contains(@data-bind,'selectIsCompany')]//span[contains(text(), 'Company')]");
        public ILocator FirstNameOnAddTransferorInfoModal => _page.Locator("//label[text()='First name *']//following-sibling::input");
        public ILocator LastNameOnAddTransferorInfoModal => _page.Locator("//label[text()='Last name *']//following-sibling::input");
        public ILocator TransferorNameOnAddTransferorInfoModal => _page.Locator("//label[text()='Transferor name *']//following-sibling::input");
        public ILocator ContactNumberOnAddTransferorInfoModal => _page.Locator("//label[text()='Contact Number']/..//input");
        public ILocator CountryDropdown => _page.Locator("//span[contains(text(),'Select Country')]");
        public ILocator TransferorCountry => _page.Locator($"//div[contains(@class,'k-list-optionlabel') and contains(text(), 'Select Country')]/..//li[contains(text(),'{transferorCountry}')]");
        public ILocator CountrySlovakiaOnAddTransferorInfoModal => _page.Locator("//li[(@class='k-item') and contains(text(), 'Slovakia')]");
        public ILocator VerticalDropdown => _page.Locator("//*[@id='addDepositorPopup']//label[contains(text(),'Vertical')]/../span");
        public ILocator IndustryDropdown => _page.Locator("//*[@id='addDepositorPopup']//label[contains(text(),'Industry')]/../span");
        public ILocator VerticalValueFromDropDown => _page.Locator("//div[contains(@class,'k-list-container')]//div[contains(text(),'Select a vertical')]//following::li[@data-offset-index='0']");
        public ILocator IndustryValueFromDropDown => _page.Locator("//div[contains(@class,'k-list-container')]//div[contains(text(),'Select an option')]//following::li[@data-offset-index='0']");
        public ILocator VerticalArtsMediaOnAddTransferorInfoModal => _page.Locator("//li[contains(@class,'k-item') and contains(text(), 'Arts + Media')]");
        public ILocator IndustryPerformingArtsOnAddTransferorInfoModal => _page.Locator("//li[contains(@class,'k-item') and contains(text(), 'Performing arts')]");
        public ILocator CountryUnitedKingdomOnAddTransferorInfoModal => _page.Locator("//li[(@class='k-item') and contains(text(), 'United Kingdom')]");
        public ILocator AddressLookupOnAddTransferorInfoModal => _page.Locator("#transferorlookup");
        public ILocator AddressLookUpManualTypingOnAddTransferorInfoModal => _page.Locator("//div[@title='I cannot find my address. Let me type it in']//u");
        public ILocator BuildingNumberOnAddTransferorInfoModal => _page.Locator("#transferorbuildingNumber");
        public ILocator StreetOnAddTransferorInfoModal => _page.Locator("#transferorstreet");
        public ILocator CityTownOnAddTransferorInfoModal => _page.Locator("#transferorcity");
        public ILocator PostcodeOnAddTransferorInfoModal => _page.Locator("#transferorpostcode");
        public ILocator AddDocumentButtonOnAddTransferorInfoModal => _page.Locator("//span[text()='Add document']");
        public ILocator AddButtonOnAddTransferorInfoModal => _page.Locator("//*[@id='addDepositorPopup']//fmfx-popup-footer/div/button[contains(text(),'Add')]");
        public ILocator UploadDocumentButton => _page.Locator(UploadDocumentButtonBy);
        public ILocator TransactionsWithAddFundsButton => _page.Locator("//div[@id='scheduledTrasactionsGrid']//*//div[text()='Status']/..//a[contains(text(),'Add funds')]");
        public ILocator ViewDetatailsButtonForSpecifiedTransaction => _page.Locator("//..//..//..//../..//a[contains(text(),'View details')]");
        public ILocator IdForSpecifiedTransaction => _page.Locator("//..//..//..//..//a[contains(@href,'instructionId')]");
        public ILocator ContinueVerificationButton => _page.Locator("//a[text()='Continue verification']");
        public ILocator TransferorDetails => _page.Locator($"//div[@id='addDepositorPopup']//label[contains(text(),'{transferorDetail}')]/..//input");
        public ILocator FreemarketFXLink => _page.Locator("//div[@title='freemarketFX']");

        public async Task UploadDocument(string Selector, string FilePath)
        {
            await _page.SetInputFilesAsync(Selector, FilePath);
        }

    }
}