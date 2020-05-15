namespace CRMUITests.Pages.Applicaton.UploadDocumentsPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class UploadDocumentsPage
    {
        public SelectElement ChooseDocument
        {
            get
            {
                return new SelectElement(this.FindElement(By.Name("chosenDoc")));
            }
        }

        public IWebElement Upload
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Прикачи')]"));
            }
        }

        public int FilesCount
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(), 'Избери файл')]")).Count;
            }
        }

        public int UploadedFilesCount
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(), 'Избери друг файл')]")).Count;
            }
        }
    }
}
