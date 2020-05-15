namespace AdminPanelUITests.UITests.APSettingsTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using AdminPanelUITests.Pages.APSettingsPage.JobPage;
    using DataDriven;
    using DataDriven.Models.AdminPanel.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;
    using AdminPanelUITests.Pages.Settings.APSettingGlobalOptions;

   
        [TestClass]
        public class JobsTests : BaseTest
        {
            private LoginPage loginPage;
            private JobPage job;
            private APSettingsGlobalOptionsPage settings;

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
                this.loginPage = new LoginPage(this.Driver);
                this.loginPage.CurrentUserLogin(BaseConstants.TestAdminPanelUrl);
                this.settings = new APSettingsGlobalOptionsPage(this.Driver);
                this.job = new JobPage(this.Driver);
                Thread.Sleep(1500);
                Thread.Sleep(1500);
                this.settings.NavigateToSettings();
                this.settings.NavigateToJobs();
            }

            [TestCleanup]
            public void TestCleanUp()
            {
                this.TestCleanup();
            }

            [Owner("Diana Grueva")]
            [Priority(1)]
            [TestCategory("Sanity")]
            [TestMethod]
            public void AssertJobsListAppear()
            {

                this.settings.AssertPage(AdminPanelConstants.JobsUrl);
                this.settings.AssertValuesInList();
            }

            [Owner("Diana Grueva")]
            [Priority(1)]
            [TestCategory("Sanity")]
            [TestMethod]
            public void AddNewJob()
            {
                var job = AccessExcelData.GetTestData<Jobs>("TestName", "Add", "Jobs", AdminPanelConstants.SettingsXlsxFilename);

                this.job.ClickAdd();
                this.job.AddNew(job);
                this.job.AssertNewEntryIsListed(job.Name);
            }

        }
    }

