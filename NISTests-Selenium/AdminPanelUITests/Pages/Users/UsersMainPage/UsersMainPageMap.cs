namespace AdminPanelUITests.Pages.Users.UsersMainPage
{
    using OpenQA.Selenium;

    public partial class UsersMainPage
    {
        public IWebElement NewUsers
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(), ' НОВ ПОТРЕБИТЕЛ')]"));
            }
        }
    }
}
