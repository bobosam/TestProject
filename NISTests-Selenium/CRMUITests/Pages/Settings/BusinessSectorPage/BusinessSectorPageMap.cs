namespace CRMUITests.Pages.Settings.BusinessSectorPage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;

    public partial class BusinessSectorPage
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

        private IWebElement Description
        {
            get
            {
                return this.FindElement(By.Id("Description"));
            }
        }

        private IWebElement DisplayOrder
        {
            get
            {
                return this.FindElement(By.Id("DisplayOrder"));
            }
        }
    }
}
