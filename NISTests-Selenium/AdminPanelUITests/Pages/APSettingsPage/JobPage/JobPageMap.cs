using OpenQA.Selenium;

namespace AdminPanelUITests.Pages.APSettingsPage.JobPage
{
    public partial class JobPage
    {
        private IWebElement Name
        {
            get
            {
                return this.FindElement(By.Id("Name"));
            }
        }

        private IWebElement Code
        {
            get
            {
                return this.FindElement(By.Id("Code"));
            }
        }

        private IWebElement NPKDCode
        {
            get
            {
                return this.FindElement(By.Id("NKPDCode"));
            }
        }

        private IWebElement IsManager
        {
            get
            {
                return this.FindElement(By.Id("IsManager"));
            }
        }
    }
}
