namespace CRMUITests.Pages.Applicaton.PrintingDocumentsPage
{
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class PrintingDocumentsPage
    {
        public SelectElement SigningType
        {
            get
            {
                return new SelectElement(this.FindElement(By.Name("appSigningTypesDropDown")));
            }
        }

        public List<IWebElement> PrintButtons
        {
            get
            {
                List<IWebElement> phones = new List<IWebElement>(this.FindElements(By.XPath("//button[contains(text(), 'Разпечатай')]")));

                return phones;
            }
        }
    }
}
