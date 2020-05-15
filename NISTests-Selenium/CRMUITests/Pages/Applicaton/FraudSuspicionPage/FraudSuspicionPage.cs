namespace CRMUITests.Pages.Applicaton.FraudSuspicionPage
{
    using DataDriven.Models.CRM.Applicaton;
    using OpenQA.Selenium;

    public partial class FraudSuspicionPage : ApplicationMainPage
    {
        public FraudSuspicionPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillFraudSuspicionPage(FraudSuspicion data)
        {
            this.IsFraud.Click();
            this.SelectByText(this.Reason, data.Reason);
            this.Type(this.Comment, data.Comment);
        }
    }
}
