namespace CRMUITests.Pages.Settings.BankPage
{
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven.Models.CRM.Settings;
    using OpenQA.Selenium;

    public partial class BankPage : SettingsGlobalOptionsPage
    {
        public BankPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Read object properties and fillout UI field, then click on save.
        /// </summary>
        /// <param name="bank"></param>
        internal void AddNew(Bank bank)
        {
            this.Type(this.Name, bank.Name);
            this.Type(this.Bic, bank.Bic);
            this.Type(this.DisplayOrder, bank.DisplayOrder);
            this.ClickSave();
        }

        /// <summary>
        /// Get first search result, click to Edit button and make changes on fields. 
        /// </summary>
        /// <param name="bank"></param>
        internal void Edit(Bank bank)
        {
            this.GetResult(1);
            this.ClickEdit();

            if (!this.Name.GetAttribute("value").Equals(bank.Name) || !bank.Name.Trim().Equals(string.Empty))
            {
                this.Type(this.Name, bank.Name);
            }

            if (!this.Bic.GetAttribute("value").Equals(bank.Bic) || !bank.Bic.Trim().Equals(string.Empty))
            {
                this.Type(this.Bic, bank.Bic);
            }

            if (!this.DisplayOrder.GetAttribute("value").Equals(bank.DisplayOrder) || !bank.DisplayOrder.Trim().Equals(string.Empty))
            {
                this.Type(this.DisplayOrder, bank.DisplayOrder);
            }
                
            this.ClickSave();
        }
    }
}
