namespace AdminPanelUITests.Pages.OrganizationUnitPage
{
    using BaseUITests;
    using DataDriven.Models.AdminPanel;
    using OpenQA.Selenium;

    public partial class OrganizationUnitPage : BasePage
    {
        public OrganizationUnitPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillUnit(OrganizationUnit unit, string action)
        {
            this.Type(this.InputName, unit.Name);
            if (action == "add")
            {
                this.ClicableSelectByText(TypeSelect, unit.Type, this.Driver);
            }
            else
            {
                this.SelectByText(ChangeTypeSelect, unit.Type);
            }
        }
    }
}
