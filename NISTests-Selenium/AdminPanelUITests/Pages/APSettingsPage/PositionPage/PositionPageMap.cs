

namespace AdminPanelUITests.Pages.APSettingsPage.PositionPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class PositionPage
    {
        private IWebElement Name
        {
            get
            {
                return this.FindElement(By.Id("Name"));
            }
        }

        private SelectElement Job
        {
            get
            {
                return new SelectElement( this.FindElement(By.Id("job")));
            }
        }

        private SelectElement Department
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("department")));
            }
        }

        private SelectElement Domain
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("domain")));
            }
        }

        private IWebElement Code
        {
            get
            {
                return this.FindElement(By.Id("code"));
            }
        }

        
    }
}
