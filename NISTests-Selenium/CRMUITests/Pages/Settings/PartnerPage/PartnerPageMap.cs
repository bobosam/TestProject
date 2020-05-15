namespace CRMUITests.Pages.Settings.PartnerPage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;

    public partial class PartnerPage
    {
        private IWebElement Name
        {
            get
            {
                return this.FindElement(By.Id("Name"));
            }
        }

        private IWebElement IsActive
        {
            get
            {
                return this.FindElement(By.XPath("//input[@type='checkbox']"));
            }
        }
    }
}
