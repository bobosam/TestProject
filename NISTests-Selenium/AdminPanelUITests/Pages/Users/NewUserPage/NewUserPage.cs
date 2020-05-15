namespace AdminPanelUITests.Pages.Users.NewUserPage
{
    using BaseUITests;
    using DataDriven.Models;
    using OpenQA.Selenium;
    using System.Threading;

    public partial class NewUserPage : BasePage
    {
        public NewUserPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillNewUser(User user)
        {
            this.Type(this.Username, user.Username);
            this.GeneratePassword.Click();
            user.Password = this.Password.GetAttribute("value");
            this.AssertPassword(user.Password);
            this.SelectByText(this.SelectStatus, user.Status);
            if (user.IsBlocked == "yes")
            {
                this.IsBlocked.Click();
            }

            this.Type(this.Email, user.Email);
            this.Type(this.PhoneNumber, user.PhoneNumber);
            this.Type(this.FirstName, user.FirstName);
            this.Type(this.SecondName, user.SecondName);
            this.Type(this.LastName, user.LastName);
            this.ClicableSelectByText(this.Department, user.Department, this.Driver);
            this.ClicableSelectByText(this.Domain, user.Domain, this.Driver);
            this.ClicableSelectByText(this.Job, user.Job, this.Driver);
            if (user.Position != null)
            {
                this.ClicableSelectByText(this.Position, user.Position, this.Driver);
            }

            this.Roles.Click();
            Thread.Sleep(500);
            this.RolesKE.Click();
            if (user.Position != null)
            {
                this.AssertCreateButton(true);
            }
            else
            {
                this.AssertCreateButton(false);
            }
        }
    }
}
