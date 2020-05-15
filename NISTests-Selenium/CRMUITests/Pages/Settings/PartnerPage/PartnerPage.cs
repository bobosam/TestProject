namespace CRMUITests.Pages.Settings.PartnerPage
{
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven.Models.CRM.Settings;
    using OpenQA.Selenium;

    public partial class PartnerPage : SettingsGlobalOptionsPage
    {
        public PartnerPage(IWebDriver driver) : base(driver)
        {
        }

        internal void AddNew(Partner partner)
        {
            this.Type(this.Name, partner.Name);
            if (!partner.IsActive)
            {
                this.IsActive.Click();
            }

            this.ClickSave();
        }

        internal void Edit(Partner partner)
        {
            if (!this.Name.GetAttribute("value").Equals(partner.Name) || !partner.Name.Trim().Equals(string.Empty))
            {
                this.Type(this.Name, partner.Name);
            }

            if (!partner.IsActive.Equals(string.Empty))
            {
                if (this.IsActive.Selected != partner.IsActive)
                {
                    this.IsActive.Click();
                }
            }

            this.ClickSave();
        }
    }
}
