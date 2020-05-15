namespace CRMUITests.Pages.Applicaton.LoanPaymentPage
{
    using DataDriven.Models.CRM.Applicaton;
    using OpenQA.Selenium;
   
    public partial class LoanPaymentPage : ApplicationMainPage
    {
        public LoanPaymentPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillLoanPayement(LoanPayment data)
        {
            this.SelectByText(this.PayoutMethod, data.PayoutMethod);
            this.Type(this.Iban, data.Iban);

            if (data.IbanOnotherPerson == "yes")
            {
                this.IbanOnotherPerson.Click();
            }
        }
    }
}
