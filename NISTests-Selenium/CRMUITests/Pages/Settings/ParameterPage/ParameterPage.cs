namespace CRMUITests.Pages.Settings.ParameterPage
{
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven.Models.CRM.Settings;
    using OpenQA.Selenium;

    public partial class ParameterPage : SettingsGlobalOptionsPage
    {
        public ParameterPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Fillout changes and click on button save.
        /// </summary>
        /// <param name="param"></param>
        internal void Edit(Parameter param)
        {
            if (!this.Value.GetAttribute("value").Equals(param.Value) || !param.Value.Trim().Equals(string.Empty))
            {
                this.Type(this.Value, param.Value);
            }

            if (!this.Description.GetAttribute("value").Equals(param.Description) || !param.Description.Trim().Equals(string.Empty))
            {
                this.Type(this.Description, param.Description);
            }

            this.ClickSave();
        }
    }
}
