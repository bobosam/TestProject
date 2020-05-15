using OpenQA.Selenium;

namespace AdminPanelUITests.Pages.APSettingsPage.PermissionPage
{
    public partial class PermissionPage
    {
        private IWebElement PermissionTable
        {
            get
            {
                return this.FindElement(By.XPath("//table"));
            }
        }
    }
}
