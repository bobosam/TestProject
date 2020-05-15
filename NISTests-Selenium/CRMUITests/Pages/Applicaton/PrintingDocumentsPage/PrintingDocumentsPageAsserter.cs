namespace CRMUITests.Pages.Applicaton.PrintingDocumentsPage
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class PrintingDocumentsPage
    {
        public void AssertPrintingButtonText(string text)
        {
            Assert.AreEqual(text.Trim(), CRMConstants.PrintingButtonText);
        }
    }
}
