namespace CRMUITests.Pages.Settings.SourcePage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;

    public partial class SourcePage
    {
        private IWebElement Name
        {
            get
            {
                return this.FindElement(By.Id("Name"));
            }
        }

        private IWebElement DisplayName
        {
            get
            {
                return this.FindElement(By.Id("DisplayName"));
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

        private IWebElement IsActive
        {
            get
            {
                return this.FindElement(By.XPath("//input[@type='checkbox']"));
            }
        }


    }
}
