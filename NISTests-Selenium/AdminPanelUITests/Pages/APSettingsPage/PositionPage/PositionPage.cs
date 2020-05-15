namespace AdminPanelUITests.Pages.APSettingsPage.PositionPage
{
    using DataDriven.Models.AdminPanel.Settings;
    using AdminPanelUITests.Pages.Settings.APSettingGlobalOptions;
    using OpenQA.Selenium;

    public partial class PositionPage : APSettingsGlobalOptionsPage
    {
        public PositionPage(IWebDriver driver) : base(driver)
        {
        }

        internal void AddNew(Positions position)
        {
            this.Type(this.Name, position.Name);
            this.SelectByText(this.Job, position.Job);
            this.SelectByText(this.Department, position.Department);
            this.SelectByText(this.Domain, position.Domain);
            this.Type(this.Code, position.Code);

            this.ClickSave();
        }

        internal void Edit(Positions position)
        {
            if (!this.Name.GetAttribute("value").Equals(position.Name) || !position.Name.Trim().Equals(string.Empty))
            {
                this.Type(this.Name, position.Name);
            }

            if (!this.Job.SelectedOption.GetAttribute("value").Equals(position.Job) || !position.Job.Trim().Equals(string.Empty))
            {
                this.SelectByText(this.Job, position.Job);
            }

            if (!this.Department.SelectedOption.GetAttribute("value").Equals(position.Department) || !position.Department.Trim().Equals(string.Empty))
            {
                this.SelectByText(this.Department, position.Department);
            }

            if (!this.Domain.SelectedOption.GetAttribute("value").Equals(position.Domain) || !position.Domain.Trim().Equals(string.Empty))
            {
                this.SelectByText(this.Domain, position.Domain);
            }

            if (!this.Code.GetAttribute("value").Equals(position.Code) || !position.Code.Trim().Equals(string.Empty))
            {
                this.Type(this.Code, position.Code);
            }

            this.ClickSave();
        }
    }
}
