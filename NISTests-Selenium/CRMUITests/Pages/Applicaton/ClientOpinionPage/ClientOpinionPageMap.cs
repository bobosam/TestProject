namespace CRMUITests.Pages.Applicaton.ClientOpinionPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class ClientOpinionPage
    {
        public SelectElement RefusalRecommendation
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("rejection-reason")));
            }
        }

        public IWebElement IsPaidByAnother
        {
            get
            {
                return this.FindElement(By.Name("otherCredit"));
            }
        }

        public SelectElement Relationship
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("clientConnection")));
            }
        }

        public IWebElement IsApprovalRecommendation
        {
            get
            {
                return this.FindElement(By.Name("clientApprove"));
            }
        }

        public SelectElement Reason
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("personKnow")));
            }
        }

        public SelectElement ChangeCoDebtor
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("CD")));
            }
        }
    }
}
