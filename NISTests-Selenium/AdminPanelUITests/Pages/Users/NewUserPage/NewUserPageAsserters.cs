using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdminPanelUITests.Pages.Users.NewUserPage
{
    public partial class NewUserPage
    {
        public void AssertPassword(string password)
        {
            Assert.IsNotNull(password, "Password");
        }

        public void AssertCreateButton(bool status)
        {
            var buttonStatus = this.Create.Enabled;

            if (status == true)
            {
                Assert.IsTrue(buttonStatus, "ButtonStatus");
            }
            else
            {
                Assert.IsFalse(buttonStatus, "ButtonStatus");
            }
        }
    }
}
