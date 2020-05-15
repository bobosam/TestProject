namespace CRMUITests.Pages.Settings.ContactPersonTypePage
{
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven.Models.CRM.Settings;
    using OpenQA.Selenium;

    public partial class ContactPersonTypePage : SettingsGlobalOptionsPage
    {
        public ContactPersonTypePage(IWebDriver driver) : base(driver)
        {
        }

        internal void AddNew(ContactPersonType contactPersonType)
        {
            this.Type(this.Name, contactPersonType.Name);
            this.Type(this.Description, contactPersonType.Description);
            this.SelectByText(this.Group, contactPersonType.Group);
            this.Type(this.Code, contactPersonType.Code);
            this.Type(this.DisplayOrder, contactPersonType.DisplayOrder);

            this.ClickSave();
        }

        internal void Edit(ContactPersonType contactPersonType)
        {
            this.GetResult(1);
            this.ClickEdit();

            if (!this.Name.GetAttribute("value").Equals(contactPersonType.Name) || !contactPersonType.Name.Trim().Equals(string.Empty))
            {
                this.Type(this.Name, contactPersonType.Name);
            }

            if (!this.Description.GetAttribute("value").Equals(contactPersonType.Description) || !contactPersonType.Description.Trim().Equals(string.Empty))
            {
                this.Type(this.Description, contactPersonType.Description);
            }

            if (!this.Group.SelectedOption.GetAttribute("value").Equals(contactPersonType.Group) || !contactPersonType.Group.Trim().Equals(string.Empty))
            {
                this.SelectByText(this.Group, contactPersonType.Group);
            }

            if (!this.Code.GetAttribute("value").Equals(contactPersonType.Code) || !contactPersonType.Code.Trim().Equals(string.Empty))
            {
                this.Type(this.Code, contactPersonType.Code);
            }

            if (!this.DisplayOrder.GetAttribute("value").Equals(contactPersonType.DisplayOrder) || !contactPersonType.DisplayOrder.Trim().Equals(string.Empty))
            {
                this.Type(this.DisplayOrder, contactPersonType.DisplayOrder);
            }

            this.ClickSave();
        }
    }
}
