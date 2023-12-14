using FMFX.PlaywrightSpecflow.Tests.PageObjects.ConsumerPortal;
using FMFX.UI.PageObjects.ConsumerPortal;
using Freemarket.Test.Utilities.Drivers;
using Freemarket.Test.Utilities.UI;
using Freemarket.Test.Utilities.Util;

namespace Freemarket.BankIntegrationTests.UI.Functions
{
    public class Withdrawal
    {
        private readonly UIActionHelper _uiActionHelper;
        private readonly DashboardPage _dashboardPage;
        private readonly BalancesPage _balancesPage;
        private readonly WithdrawalForm _withdrawalForm;
        private readonly Driver _driver;

        public Withdrawal(UIActionHelper uIActionHelper, Driver driver)
        {
            _uiActionHelper = uIActionHelper;
            _driver = driver;
            _dashboardPage = new DashboardPage(_driver.Page);
            _balancesPage = new BalancesPage(_driver.Page, _uiActionHelper);
            _withdrawalForm = new WithdrawalForm(_driver.Page, _uiActionHelper);
        }

        public void GoToBalancesPage()
        {
            _uiActionHelper.WaitForElementToBeVisible(_dashboardPage.LinkBalances, 10);
            _uiActionHelper.Click(_dashboardPage.LinkBalances);
        }

        public void SelectCurrencyAndAmount(string currency, decimal Amount)
        {
            _uiActionHelper.Click(_balancesPage.GetCurrencyLink(currency));
            _uiActionHelper.Click(_balancesPage.WithdrawFunds);
            _uiActionHelper.EnterText(_withdrawalForm.InputWithdrawalAmount, Amount.ToString());
            _uiActionHelper.Click(_balancesPage.ContinueButton);
        }

        public void SelectUltimateOrginator(string originitorName)
        {
            if (_uiActionHelper.IsVisible(_withdrawalForm.UltimateOriginatorYesButton))
            {
                _uiActionHelper.Click(_withdrawalForm.UltimateOriginatorYesButton);
            }
        }

        public string SelectBeneficiary(string beneficiaryName, string reasonForTransaction)
        {
            string reference = DateTime.Now.ToString("ddMMhhmmss");
            _withdrawalForm.SelectBeneficiary(beneficiaryName);
            _uiActionHelper.EnterText(_withdrawalForm.InputReference, $"Test{reference}");
            _uiActionHelper.EnterText(_withdrawalForm.InputDescription, $"DOP{reference}");
            _withdrawalForm.SelectReasonForTransaction(reasonForTransaction);
            _uiActionHelper.Click(_balancesPage.ContinueButton);

            return $"Test{reference}";
        }

        public void SelectChargeBearer(string chargeBrearer)
        {
            if(chargeBrearer.ToUpper().Equals("SHA"))
            {
                if(_uiActionHelper.IsVisible(_withdrawalForm.LabelTransactionChargeSha))
                {
                    _uiActionHelper.Click(_withdrawalForm.LabelTransactionChargeSha);
                }
            }
            if(chargeBrearer.ToUpper().Equals("OUR"))
            {
                if (_uiActionHelper.IsVisible(_withdrawalForm.LabelTransactionChargeOur))
                {
                    _uiActionHelper.Click(_withdrawalForm.LabelTransactionChargeOur);
                }
            }

            _uiActionHelper.Click(_balancesPage.ContinueButton);
        }

        public string GetWithdrawalId()
        {
            string id = string.Empty;
            return id;
        }

    }
}
