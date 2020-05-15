namespace CRMUITests.Pages.Applicaton.OtherCreditsPage
{
    using DataDriven.Models.CRM.Applicaton;
    using OpenQA.Selenium;

    public partial class OtherCreditsPage : ApplicationMainPage
    {
        public OtherCreditsPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillCredits(CreditsInfo info)
        {
            this.FillCDCredits(info);

            if (info.Refinansng != null)
            {
                this.Refinansing.Click();
            }

            //this.Type(this.CreditParameters[3], info.Iban);
            //this.Type(this.CreditParameters[4], info.RefinansingAmount);
        }

        public void FillCDCredits(CreditsInfo info)
        {
            //this.AddCredit.Click();
            //this.SelectByText(this.Creditor, info.Creditor);
            //this.Type(this.Amount, info.Amount);
            //this.Type(this.CreditParameters[0], info.LoanTerm);
            //this.Type(this.CreditParameters[1], info.RemainingInstallments);
            //this.Type(this.CreditParameters[2], info.MonthlyAmount);
            //this.SelectByText(this.CreditType, info.CreditType);

            if (info.Distraint != null)
            {
                this.Distraint.Click();
            }
        }
    }
}
