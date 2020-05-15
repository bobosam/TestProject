using AdminPanelUITests.Pages.APHomePage;
using AdminPanelUITests.Pages.Users.NewUserPage;
using AdminPanelUITests.Pages.Users.UsersMainPage;
using BaseUITests;
using BaseUITests.Pages.LoginPage;
using DataDriven;
using DataDriven.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace AdminPanelUITests.UITests
{
    [TestClass]
    public class UsersTests : BaseTest
    {

        private APHomePage homePage;
        private LoginPage loginPage;
        private UsersMainPage usersMainPage;
        private NewUserPage newUserPage;

        [ClassInitialize]
        public static void ClassInit(TestContext con)
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        [TestInitialize]
        public void TestIniti()
        {
            this.TestInitialize();
            this.homePage = new APHomePage(this.Driver);
            this.loginPage = new LoginPage(this.Driver);
            this.usersMainPage = new UsersMainPage(this.Driver);
            this.newUserPage = new NewUserPage(this.Driver);

            var user = AccessExcelData.GetTestData<User>("TestName", "TestUser", "Users", BaseConstants.UsersXlsxFilename);
            this.loginPage.AnotherUserLogin(user, BaseConstants.TestAdminPanelUrl);
            Thread.Sleep(3000);
            this.homePage.Users.Click();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            this.TestCleanup();
        }

        [Owner("Boyko Andonov")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestCategory("APUsers")]
        [TestMethod]
        public void CreateNewUser()
        {
            this.usersMainPage.NewUsers.Click();
            var user = AccessExcelData.GetTestData<User>("TestName", "NewUser", "Users", BaseConstants.UsersXlsxFilename);
            this.newUserPage.FillNewUser(user);
        }
    }
}
