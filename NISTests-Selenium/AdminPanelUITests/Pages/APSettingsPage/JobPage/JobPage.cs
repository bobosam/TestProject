namespace AdminPanelUITests.Pages.APSettingsPage.JobPage
{
    using BaseUITests;
    using OpenQA.Selenium;
    using DataDriven.Models.AdminPanel.Settings;
    using AdminPanelUITests.Pages.Settings.APSettingGlobalOptions;

    public partial class JobPage : APSettingsGlobalOptionsPage
    {
        public JobPage(IWebDriver driver) : base(driver)
        {
        }

        internal void AddNew(Jobs job)
        {
            this.Type(this.Name, job.Name);
            this.Type(this.Code, job.Code);
            this.Type(this.NPKDCode, job.NPKDCode);

            if (!job.IsManager)
            {
                this.IsManager.Click();
            }

            this.ClickSave();
        }

        internal void Edit(Jobs job)
        {
            if (!this.Name.GetAttribute("value").Equals(job.Name) || !job.Name.Trim().Equals(string.Empty))
            {
                this.Type(this.Name, job.Name);
            }
            if (!this.Code.GetAttribute("value").Equals(job.Code) || !job.Code.Trim().Equals(string.Empty))
            {
                this.Type(this.Code, job.Code);
            }
            if (!this.NPKDCode.GetAttribute("value").Equals(job.NPKDCode) || !job.NPKDCode.Trim().Equals(string.Empty))
            {
                this.Type(this.NPKDCode, job.NPKDCode);
            }
            if (!job.IsManager.Equals(string.Empty))
            {
                if (this.IsManager.Selected != job.IsManager)
                {
                    this.IsManager.Click();
                }
            }

            this.ClickSave();
        }
    }
}
