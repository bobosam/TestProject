namespace CRMUITests.Pages.Settings.BankPage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;

    public partial class BankPage
    {
        private IWebElement Id
        {
            get
            {
                return this.FindElement(By.Id("Id"));
            }
        }

        private IWebElement Name
        {
            get
            {
                return this.FindElement(By.Id("Name"));
            }
        }

        private IWebElement Bic
        {
            get
            {
                return this.FindElement(By.Id("BIC"));
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
