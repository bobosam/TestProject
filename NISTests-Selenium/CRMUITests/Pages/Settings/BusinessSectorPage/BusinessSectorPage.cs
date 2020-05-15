namespace CRMUITests.Pages.Settings.BusinessSectorPage
{
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven.Models.CRM.Settings;
    using OpenQA.Selenium;

    public partial class BusinessSectorPage : SettingsGlobalOptionsPage
    {
        public BusinessSectorPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Fillout all fields and click on Save.
        /// </summary>
        /// <param name="bSector"></param>
        internal void AddNew(BusinessSector bSector)
        {
            this.Type(this.Name, bSector.Name);
            this.Type(this.Code, bSector.Code);
            this.Type(this.Description, bSector.Description);
            this.Type(this.DisplayOrder, bSector.DisplayOrder);
            this.ClickSave();
        }

        /// <summary>
        /// Get first search result, click to Edit button and make changes on fields. 
        /// </summary>
        /// <param name="bSector"></param>
        internal void Edit(BusinessSector bSector)
        {
            this.GetResult(1);
            this.ClickEdit();

            if (!this.Name.GetAttribute("value").Equals(bSector.Name) || !bSector.Name.Trim().Equals(string.Empty))
            {
                this.Type(this.Name, bSector.Name);
            }

            if (!this.Code.GetAttribute("value").Equals(bSector.Code) || !bSector.Code.Trim().Equals(string.Empty))
            {
                this.Type(this.Code, bSector.Code);
            }

            if (!this.Description.GetAttribute("value").Equals(bSector.Description) || !bSector.Description.Trim().Equals(string.Empty))
            {
                this.Type(this.Description, bSector.Description);
            }

            if (!this.DisplayOrder.GetAttribute("value").Equals(bSector.DisplayOrder) || !bSector.DisplayOrder.Trim().Equals(string.Empty))
            {
                this.Type(this.DisplayOrder, bSector.DisplayOrder);
            }

            this.ClickSave();
        }
    }
}
