namespace BaseUITests.Pages.LoginPage
{
    using DataDriven.Models;
    using OpenQA.Selenium;
   
    public partial class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }
        
        /// <summary>
        /// Navigate to Login Page and click on Windows Authorization login(Current User).
        /// </summary>
        public void CurrentUserLogin(string url)
        {
            this.NavigateTo(url);
            this.CurrentUser.Click();
        }

        /// <summary>
        /// Navigate to Login Page and click on Another User Login.
        /// </summary>
        /// <param name="user"></param>
        public void AnotherUserLogin(User user, string url)
        {
            this.NavigateTo(url);
            this.АnotherUser.Click();
            this.FillLoginForm(user);
            this.Login.Click();
        }

        /// <summary>
        /// Navigate to Login Page.
        /// </summary>
        private void NavigateTo(string url)
        {
            this.Driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// Fillout username and password for login with Another User.
        /// </summary>
        /// <param name="user"></param>
        private void FillLoginForm(User user)
        {
            this.Type(this.Username, user.Username);
            this.Type(this.Password, user.Password);
        }
    }
}
