namespace CRMUITests.Pages.Applicaton.ClientOpinionPage
{
    using DataDriven.Models.CRM.Applicaton;
    using OpenQA.Selenium;
   
    public partial class ClientOpinionPage : ApplicationMainPage
    {
        public ClientOpinionPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillClientOpinionPage(ClientOpinion data)
        {
            this.SelectByText(this.RefusalRecommendation, data.RefusalRecommendation);
            this.IsPaidByAnother.Click();
            this.SelectByText(this.Relationship, data.Relationship);
            this.IsApprovalRecommendation.Click();
            this.SelectByText(this.Reason, data.Reason);
            this.SelectByText(this.ChangeCoDebtor, data.ChangeCoDebtor);
        }
    }
}
