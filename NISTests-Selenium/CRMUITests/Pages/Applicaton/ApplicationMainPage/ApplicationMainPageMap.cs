namespace CRMUITests.Pages.Applicaton
{
    using System.Collections.Generic;

    using OpenQA.Selenium;
   
    public partial class ApplicationMainPage
    {
        public IWebElement NewApplication
        {
            get
            {
                return this.FindElement(By.CssSelector("#page-content-wrapper > div > div > div > app-applications > app-applications-select > app-applications-list > div > div.row.page-header > div.col-lg-7 > div > button"));
            }
        }

        public IWebElement ApplicationNumber
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Номер на апликация:')]/../input"));
            }
        }

        public IWebElement ApplicationStatus
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Статус:')]/../input"));
            }
        }

        public IWebElement ClRejected
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Отказана от клиент')]"));
            }
        }

        public IWebElement Back
        {
            get
            {
                return this.FindElement(By.XPath("//span[contains(text(),'Назад')]"));
            }
        }

        public virtual IWebElement SaveAndContinueButton
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Запиши и продължи')]/.."));
            }
        }

        public virtual IWebElement BackYes
        {
            get
            {
                return this.FindElement(By.XPath("//p-footer/div/button[2]"));
            }
        }

        public List<IWebElement> WarningMsg
        {
            get
            {
                List<IWebElement> warningMsg = new List<IWebElement>();
                warningMsg.AddRange(Driver.FindElements(By.XPath("Полето е задължително!")));
                warningMsg.AddRange(Driver.FindElements(By.XPath("Моля, пишете на кирилица!")));
                warningMsg.AddRange(Driver.FindElements(By.XPath("Невалиден номер!")));
                warningMsg.AddRange(Driver.FindElements(By.XPath("Моля, въведете стойност!")));
                warningMsg.AddRange(Driver.FindElements(By.XPath("Грешна стойност!")));
                return warningMsg;
            }
        }
    }
}
