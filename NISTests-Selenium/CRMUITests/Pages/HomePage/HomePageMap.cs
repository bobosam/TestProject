namespace CRMUITests.Pages.HomePage
{
    using OpenQA.Selenium;

    public partial class HomePage
    {
        public IWebElement ProfiCreditCRM
        {
            get
            {
                return this.FindElement(By.CssSelector("#page-content-wrapper > div > div > div > ng-component > app-about > div > div > div > h1 > strong"));
            }
        }

        public IWebElement Logout
        {
            get
            {
                return this.FindElement(By.XPath("/html/body/app-root/app-public-layout/div[1]/div/div/div[2]/div/div[4]/a/img"));
            }
        }

        public IWebElement Offers
        {
            get
            {
                return this.FindElement(By.XPath("//strong[contains(text(), 'Оферти')]"));
            }
        }

        public IWebElement Applications
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Апликации')]"));
            }
        }

        public IWebElement Requests
        {
            get
            {
                return this.FindElement(By.XPath("//strong[contains(text(),'Заявки')]"));
            }
        }
    }
}
