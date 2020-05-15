namespace CRMUITests.Pages.Settings.SourcePage
{
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven.Models.CRM.Settings;
    using OpenQA.Selenium;

    public partial class SourcePage : SettingsGlobalOptionsPage
    {
        public SourcePage(IWebDriver driver) : base(driver)
        {
        }
        /// <summary>
        /// Write in all fillout fields and click button OK.
        /// </summary>
        /// <param name="source"></param>
        internal void AddNew(Source source)
        {
            Type(this.Name, source.Name);
            Type(this.DisplayName, source.DisplayName);
            Type(this.Description, source.Description);
            Type(this.DisplayOrder, source.DisplayOrder);
            if (!source.IsActive)
            {
                this.IsActive.Click();
            }

            this.ClickSave();
        }

        /// <summary>
        /// Type the changes and click on OK button.
        /// </summary>
        /// <param name="source"></param>
        internal void Edit(Source source)
        {
            if (!this.Name.GetAttribute("value").Equals(source.Name) || !source.Name.Trim().Equals(string.Empty))
            {
                Type(this.Name, source.Name);
            }

            if (!this.DisplayName.GetAttribute("value").Equals(source.DisplayName) || !source.DisplayName.Trim().Equals(string.Empty))
            {
                Type(this.DisplayName, source.DisplayName);
            }

            if (!this.Description.GetAttribute("value").Equals(source.Description) || !source.Description.Trim().Equals(string.Empty))
            {
                Type(this.Description, source.Description);
            }

            if (!this.DisplayOrder.GetAttribute("value").Equals(source.DisplayOrder) || !source.DisplayOrder.Trim().Equals(string.Empty))
            {
                Type(this.DisplayOrder, source.DisplayOrder);
            }

            if (!source.IsActive.Equals(string.Empty))
            {
                if (this.IsActive.Selected != source.IsActive)
                {
                    this.IsActive.Click();
                }
            }

            this.ClickSave();
        }
    }
}
