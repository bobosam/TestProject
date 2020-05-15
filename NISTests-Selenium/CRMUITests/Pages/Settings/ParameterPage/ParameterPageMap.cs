namespace CRMUITests.Pages.Settings.ParameterPage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;

    public partial class ParameterPage
    {
        private IWebElement Value
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
                return this.FindElement(By.XPath("//*[contains(text(),'Описание')]/../../../div[2]/input"));
            }
        }

        private IWebElement Module
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Модул')]/../../../div[2]/input"));
            }
        }

        private IWebElement ParamType
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Тип на стойност:')]/../../../div[2]/input"));
            }
        }

        private IWebElement ParamName
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Име на параметъра:')]/../../../div[2]/input"));
            }
        }

        private IWebElement Code
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Код:')]/../../../div[2]/input"));
            }
        }
    }
}
