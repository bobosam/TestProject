namespace AdminPanelUITests.Pages.APHomePage
{
    using OpenQA.Selenium;

    public partial class APHomePage
    {
        public IWebElement Home
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Начало')]"));
            }
        }

        public IWebElement Users
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Потребители')]"));
            }
        }

        public IWebElement Settings
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Настройки')]"));
            }
        }

        public IWebElement OrganizationUnits
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Звена')]"));
            }
        }
    }
}
