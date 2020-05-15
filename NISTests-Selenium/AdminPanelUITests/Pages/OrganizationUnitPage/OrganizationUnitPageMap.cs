namespace AdminPanelUITests.Pages.OrganizationUnitPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class OrganizationUnitPage
    {
        public IWebElement Marketing
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Маркетинг')]"));
            }
        }

        public IWebElement Sales
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Продажби')]"));
            }
        }

        public IWebElement It
        {
            get
            {
                return this.FindElement(By.XPath("//span[contains(text(), 'IT')]"));
            }
        }

        public IWebElement AddUnit
        {
            get
            {
                return this.FindElement(By.XPath("//span[contains(text(), 'Добави')]"));
            }
        }

        public IWebElement UpdateUnit
        {
            get
            {
                return this.FindElement(By.XPath("//span[contains(text(), 'Редактирай')]"));
            }
        }

        public IWebElement DeleteUnit
        {
            get
            {
                return this.FindElement(By.XPath("//span[contains(text(), 'Изтрий')]"));
            }
        }

        public IWebElement InputName
        {
            get
            {
                return this.FindElement(By.Id("inputName"));
            }
        }

        public SelectElement TypeSelect
        {
            get
            {
                return new SelectElement( this.FindElement(By.XPath("//*[@id='unitTypeundefined']/div/div[1]/select")));
            }
        }

        public SelectElement ChangeTypeSelect
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='unitType1']/div/div[1]/select")));
            }
        }

        public IWebElement TypeTelemark
        {
            get
            {
                return this.FindElement(By.CssSelector("#unitType1 > div > div:nth-child(1) > select > option:nth-child(2)"));
            }
        }

        public IWebElement Reject
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(), 'Отказ')]"));
            }
        }

        public IWebElement DoNotDelete
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(), 'Не')]"));
            }
        }
    }
}
