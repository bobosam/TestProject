namespace CRMUITests.Pages.Settings.IncomeTermTypePage
{
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven.Models.CRM.Settings;
    using OpenQA.Selenium;

    public partial class IncomeTermTypePage : SettingsGlobalOptionsPage
    {
        public IncomeTermTypePage(IWebDriver driver) : base(driver)
        {
        }

        internal void AddNew(IncomeTermType incomeTermType)
        {
            this.Type(this.Name, incomeTermType.Name);
            this.Type(this.Description, incomeTermType.Description);
            this.SelectByText(this.Types, incomeTermType.Type);
            this.Type(this.Code, incomeTermType.Code);
            this.Type(this.DisplayOrder, incomeTermType.DisplayOrder);
            this.ClickSave();
        }

        internal void Edit(IncomeTermType incomeTermType)
        {
            this.GetResult(1);
            this.ClickEdit();

            if (!this.Name.GetAttribute("value").Equals(incomeTermType.Name) || !incomeTermType.Name.Trim().Equals(string.Empty))
            {
                this.Type(this.Name, incomeTermType.Name);
            }

            if (!this.Description.GetAttribute("value").Equals(incomeTermType.Description) || !incomeTermType.Description.Trim().Equals(string.Empty))
            {
                this.Type(this.Description, incomeTermType.Description);
            }

            if (!this.Types.SelectedOption.GetAttribute("value").Equals(incomeTermType.Type) || !incomeTermType.Type.Trim().Equals(string.Empty))
            {
                this.SelectByText(this.Types, incomeTermType.Type);
            }

            if (!this.Code.GetAttribute("value").Equals(incomeTermType.Code) || !incomeTermType.Code.Trim().Equals(string.Empty))
            {
                this.Type(this.Code, incomeTermType.Code);
            }

            if (!this.DisplayOrder.GetAttribute("value").Equals(incomeTermType.DisplayOrder) || !incomeTermType.DisplayOrder.Trim().Equals(string.Empty))
            {
                this.Type(this.DisplayOrder, incomeTermType.DisplayOrder);
            }

            this.ClickSave();
        }
    }
}
