namespace AdminPanelUITests.Pages.APSettingsPage.RolePage
{
    using BaseUITests;
    using DataDriven.Models.AdminPanel.Settings;
    using AdminPanelUITests.Pages.Settings.APSettingGlobalOptions;
    using OpenQA.Selenium;

    public partial class RolePage : APSettingsGlobalOptionsPage
    {
        public RolePage(IWebDriver driver) : base(driver)
        {
        }

        internal void AddNew(Roles role)
        {
            
            this.Type(this.Name, role.Name);
            

            this.ClickSave();
        }
    }
}
