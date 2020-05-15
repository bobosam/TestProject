namespace BaseUITests.Pages.LoginPage
{
    using OpenQA.Selenium;

    public partial class LoginPage
    {
        public IWebElement CurrentUser
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Вход като:')]"));
            }
        }

        public IWebElement АnotherUser
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Вход с друг акаунт')]"));
            }
        }

        public IWebElement Username
        {
            get
            {
                return this.FindElement(By.Id("username"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.FindElement(By.Id("password"));
            }
        }

        public IWebElement Login
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Вход в системата')]"));
            }
        }

        public IWebElement Back
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Назад')]"));
            }
        }

        public IWebElement WrongData
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Грешно потребителско име или парола!')]"));
            }
        }
    }
}
