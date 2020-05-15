namespace CRMUITests.Pages.Applicaton.LoanPaymentPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class LoanPaymentPage
    {
        public SelectElement PayoutMethod
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("bankTranck")));
            }
        }

        public IWebElement Iban
        {
            get
            {
                return this.FindElement(By.Id("iban"));
            }
        }

        public IWebElement IbanOnotherPerson
        {
            get
            {
                return this.FindElement(By.Id("ibanPerson"));
            }
        }
    }
}
