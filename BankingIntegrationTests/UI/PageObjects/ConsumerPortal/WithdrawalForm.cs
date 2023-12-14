using Freemarket.Test.Utilities.UI;
using Freemarket.Test.Utilities.Util;
using Microsoft.Playwright;


namespace FMFX.UI.PageObjects.ConsumerPortal
{
    public class WithdrawalForm
    {
        private readonly IPage _page;
        private readonly UIActionHelper _uiActionHelper;
        public WithdrawalForm(IPage page,
                              UIActionHelper uIActionHelper)
        {
            _page = page;
            _uiActionHelper = uIActionHelper;
            
        }

        public ILocator FormHeader => _page.Locator($"//h1[text()='Withdraw funds']");
        public ILocator BatchFileUploadButton => _page.Locator("//input[@type='file']");
        public ILocator BtnConfirm => _page.Locator("//*[text()='Confirm']");
        public ILocator InputWithdrawalAmount => _page.Locator($"//div/label[@for='withdrawalAmount']/parent::div/span/span/input").First;
        public ILocator ButtonContinue => _page.Locator("#continue");
        public ILocator DropDownBeneficiary => _page.Locator($"//div/label[text()='Select existing beneficiary']/parent::div/span[@role='listbox']");
        public ILocator InputSelectBeneficiary => _page.Locator($"//div/div/span/input[@class='k-textbox']");
        public ILocator InputReference => _page.Locator("#reference");
        public ILocator InputDescription => _page.Locator("#description");
        public ILocator UploadImageButton => _page.Locator("//*[@id='uploadImageBtn']/span[text()='Add supporting document']");
        public ILocator DropDownReasonForTransaction => _page.Locator($"//div/label[text()='Reason for transaction']/parent::div//span[text()='Select...']");
        public ILocator UltimateOriginatorYesButton => _page.Locator("//h2[text()='Ultimate originator']//following::a[contains(@data-bind, 'setUserIsUltimateOriginator') and text()='Yes']");
        public ILocator LabelTransactionChargeSha => _page.Locator("//a[@id='sell']/span");
        public ILocator LabelTransactionChargeOur => _page.Locator("//a[@id='buy']/span");
        public void SelectBeneficiary(string beneName)
        {
            string optionString = "//div/ul/li[text()='" + beneName + "']";
            _uiActionHelper.Click(DropDownBeneficiary);
            _uiActionHelper.WaitForElementToBeVisible(InputSelectBeneficiary, 3);
            _uiActionHelper.EnterText(InputSelectBeneficiary, beneName);
            _uiActionHelper.Click(_uiActionHelper.GetElement(optionString));

        }

        public void SelectReasonForTransaction(string reason)
        {
            string optionString = "//div/ul/li[text()='" + reason + "']";
            _uiActionHelper.Click(DropDownReasonForTransaction);
            _uiActionHelper.Click(_uiActionHelper.GetElement(optionString));
        }

        public void ClickConfirm()
        {
            _uiActionHelper.Click(BtnConfirm);
        }


    }
}
