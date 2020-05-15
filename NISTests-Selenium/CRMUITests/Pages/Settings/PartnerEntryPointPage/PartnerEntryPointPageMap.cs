namespace CRMUITests.Pages.Settings.PartnerEntryPointPage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;

    public partial class PartnerEntryPointPage
    {
        private IWebElement Name
        {
            get
            {
                return this.FindElement(By.XPath("//div[@class='modal-content']//*[@id='Name']"));
            }
        }

        private IWebElement DisplayOrder
        {
            get
            {
                return this.FindElement(By.XPath("//div[@class='modal-content']//*[@id='DisplayOrder']"));
            }
        }

        private IWebElement IsActive
        {
            get
            {
                return this.FindElement(By.XPath("//div[@class='modal-content']//strong[contains(text(),'Активен')]/../input[@type='checkbox']"));
            }
        }

        private IWebElement IsPhysically
        {
            get
            {
                return this.FindElement(By.XPath("//strong[contains(text(),'Физически')]/../input[@type='checkbox']"));
            }
        }

        private IWebElement IsSystem
        {
            get
            {
                return this.FindElement(By.XPath("//strong[contains(text(),'Системен')]/../input[@type='checkbox']"));
            }
        }

        private IWebElement AddEntryPoint
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(),'Добави')]"));
            }
        }

        private IList<IWebElement> EPointsList
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(),'точки')]/../../../..//table//tr"));
            }
        }
    }
}
