namespace CRMUITests.Pages.Applicaton.UploadDocumentsPage
{
    using System.IO;
    using System.Threading;

    using DataDriven;
    using DataDriven.Models.CRM.Applicaton;
    using OpenQA.Selenium;
   
    public partial class UploadDocumentsPage : ApplicationMainPage
    {
        public UploadDocumentsPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillUploadDocuments(UploadDocuments data)
        {
            var directory = HelpMethods.GetDirectory();
            var path = Path.GetFullPath(Path.Combine(directory, @"..\Logs\" + CRMConstants.UploadFile));
            var count = this.FilesCount;
            var uploadedCount = 0;

            while (uploadedCount < count)
            {
                Thread.Sleep(500);
                this.Driver.FindElement(By.XPath("//input[@type='file']")).SendKeys(path);

                Thread.Sleep(500);
                this.Upload.Click();
                Thread.Sleep(1000);
                uploadedCount = this.UploadedFilesCount;
            }
        }
    }
}
