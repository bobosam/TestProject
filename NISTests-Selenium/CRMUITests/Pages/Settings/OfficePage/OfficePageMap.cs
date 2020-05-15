namespace CRMUITests.Pages.Settings.OfficePage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class OfficePage
    {
        private IWebElement Name
        {
            get
            {
                return this.FindElement(By.Id("Name"));
            }
        }

        private IWebElement DispayName
        {
            get
            {
                return this.FindElement(By.Id("NameForVisualization"));
            }
        }

        private IWebElement Address
        {
            get
            {
                return this.FindElement(By.Id("Address"));
            }
        }

        //private SelectElement Settlement
        //{
        //    get
        //    {
        //        return new SelectElement(this.FindElement(By.XPath("//input[@placeholder='Населено място']")));
        //    }
        //}
        private IWebElement Settlement
        {
            get
            {
                return this.FindElement(By.XPath("//input[@placeholder='Населено място']"));
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
