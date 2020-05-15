namespace CRMUITests.Pages.Applicaton.LoanParametersPage
{
    using System.Threading;

    using DataDriven.Models.CRM.Applicaton;
    using OpenQA.Selenium;

    public partial class LoanParametersPage : ApplicationMainPage
    {
        public LoanParametersPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillLoanParameters(LoanParameters parameters)
        {
            Thread.Sleep(2500);
            if (parameters.Pid != "null")
            {
                this.Type(this.Pid, parameters.Pid);
            }
            else if (this.Pid.GetAttribute("value").ToString().Trim() == string.Empty)
            {
                this.AssertMissingPid();
            }

            Thread.Sleep(1000);
            this.ClicableSelectByText(this.ProductType, parameters.ProductType, Driver);
            this.ClicableSelectByText(this.LoanAmount, parameters.LoanAmount, Driver);
            if (parameters.LoanRate != "null")
            {
                this.ClicableSelectByText(this.LoanRate, parameters.LoanRate, Driver);
                Thread.Sleep(500);
                this.AssertMonthlyAmountExist();
            }

            if (parameters.PaymentDate != "null")
            {
                this.ClicableSelectByText(this.PaymentDate, parameters.PaymentDate, Driver);
            }

            if (parameters.LoanPurpose != "null")
            {
                this.ClicableSelectByText(this.LoanPurpose, parameters.LoanPurpose, Driver);
            }

            if (parameters.RequestSource != "null")
            {
                this.ClicableSelectByText(this.RequestSource, parameters.RequestSource, Driver);
            }
        }
    }
}
