using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdminPanelUITests.Pages.APSettingsPage.RolePage
{
    public partial class RolePage
    {
        private IWebElement Name
        {
            get
            {
                return this.FindElement(By.Id("Name"));
            }
        }

        //private IWebElement Code
        //{
        //    get
        //    {
        //        return this.FindElement(By.Id("code"));
        //    }
        //}
    }
}
