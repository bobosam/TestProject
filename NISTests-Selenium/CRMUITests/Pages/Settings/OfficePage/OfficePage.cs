namespace CRMUITests.Pages.Settings.OfficePage
{
    using System.Threading;

    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven.Models.CRM.Settings;
    using OpenQA.Selenium;
    
    public partial class OfficePage : SettingsGlobalOptionsPage
    {
        public OfficePage(IWebDriver driver) : base(driver)
        {
        }

        internal void AddNew(Office office)
        {
            this.Type(this.Name, office.Name);
            this.Type(this.DispayName, office.DisplayName);
            this.Type(this.Address, office.Address);
            this.Type(this.Settlement, office.Settlement);
            Thread.Sleep(1000);
            this.Driver.FindElement(By.XPath("//ngb-modal-window//p-autocomplete//li")).Click();

            // SelectByText(this.Settlement, office.Settlement); //ngb-modal-window//p-autocomplete//li
            this.Type(this.DisplayOrder, office.DisplayOrder);
            if (!office.IsActive)
            {
                this.IsActive.Click();
            }
            
            this.ClickSave();
        }

        internal void Edit(Office office)
        {
            this.GetResult(1);
            this.ClickEdit();

            if (!this.Name.GetAttribute("value").Equals(office.Name) || !office.Name.Trim().Equals(string.Empty))
            {
                this.Type(this.Name, office.Name);
            }

            if (!this.DispayName.GetAttribute("value").Equals(office.DisplayName) || !office.DisplayName.Trim().Equals(string.Empty))
            {
                this.Type(this.DispayName, office.DisplayName);
            }

            if (!this.Address.GetAttribute("value").Equals(office.Address) || !office.Address.Trim().Equals(string.Empty))
            {
                this.Type(this.Address, office.Address);
            }

            if (!this.Settlement.GetAttribute("value").Equals(office.Settlement) || !office.Settlement.Trim().Equals(string.Empty))
            {
                //SelectByText(this.Settlement, office.Settlement);
                this.Type(this.Settlement, office.Settlement);
                Thread.Sleep(1000);
                this.Driver.FindElement(By.XPath("//p-autocomplete//li")).Click();
            }

            if (!this.DisplayOrder.GetAttribute("value").Equals(office.DisplayOrder) || !office.DisplayOrder.Trim().Equals(string.Empty))
            {
                this.Type(this.DisplayOrder, office.DisplayOrder);
            }

            if (!office.IsActive.Equals(string.Empty))
            {
                if (this.IsActive.Selected != office.IsActive)
                {
                    this.IsActive.Click();
                }
            }

            this.ClickSave();
        }
    }
}
