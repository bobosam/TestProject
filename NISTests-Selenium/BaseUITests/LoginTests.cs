namespace BaseUITests
{
    using DataDriven;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using BaseUITests.Pages.LoginPage;
    using DataDriven.Models;

    [TestClass]
    public class LoginTests : BaseTest
    {
        private LoginPage loginPage;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
        }

        [ClassCleanup]
        public static void ClassClean()
        {
        }

        [TestInitialize]
        public void TestInit()
        {
            this.TestInitialize();
            this.loginPage = new LoginPage(Driver);
        }

        [TestCleanup]
        public void TestClean()
        {
            this.TestCleanup();
        }

        [Priority(1)]
        [TestCategory("valid")]
        [Owner("Boyko Andonov")]
        [TestCategory("BaseLogin")]
        [TestMethod]
        public void LoginCurrentUserTest()
        {
            string currentUser = Environment.UserName;
            this.loginPage.CurrentUserLogin(BaseConstants.TestCRMUrl);
            this.loginPage.AssertValidUser();
        }

        [Priority(2)]
        [TestCategory("valid")]
        [Owner("Boyko Andonov")]
        [TestCategory("BaseLogin")]
        [TestMethod]
        public void LoginAnotherUserTest()
        {
            string[] users = new string[] { "invalidNameInvalidPass", "invalidPass", "invalidName", "ke.pleven" };

            foreach (var key in users)
            {
                var user = AccessExcelData.GetTestData<User>("TestName", key, "Users", BaseConstants.UsersXlsxFilename);
                this.loginPage.AnotherUserLogin(user, BaseConstants.TestCRMUrl);

                if (user.AssertType == "valid")
                {
                    loginPage.AssertValidUser();
                }
                else
                {
                    loginPage.AssertInvalidUser();
                }
            }
        }
    }
}
