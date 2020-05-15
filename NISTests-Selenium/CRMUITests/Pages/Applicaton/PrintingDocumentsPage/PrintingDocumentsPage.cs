namespace CRMUITests.Pages.Applicaton.PrintingDocumentsPage
{
    using DataDriven.Models.CRM.Applicaton;
    using OpenQA.Selenium;

    public partial class PrintingDocumentsPage : ApplicationMainPage
    {
        public PrintingDocumentsPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillPrintingDocumentsManual(PrintingDocuments data)
        {
            this.SelectByText(this.SigningType, data.SigningType);
            foreach (var button in this.PrintButtons)
            {
                button.Click();
                this.AssertPrintingButtonText(button.Text);
            }
        }
    }
}
