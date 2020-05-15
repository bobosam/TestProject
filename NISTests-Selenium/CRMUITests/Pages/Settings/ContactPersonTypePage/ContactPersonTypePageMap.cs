namespace CRMUITests.Pages.Settings.ContactPersonTypePage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class ContactPersonTypePage
    {
        private IWebElement Name
        {
            get
            {
                return this.FindElement(By.Id("Name"));
            }
        }

        private IWebElement Description
        {
            get
            {
                return this.FindElement(By.Id("Description"));
            }
        }

        private SelectElement Group
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("groupContact")));
            }
        }

        private IWebElement Code
        {
            get
            {
                return this.FindElement(By.Id("Code"));
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
