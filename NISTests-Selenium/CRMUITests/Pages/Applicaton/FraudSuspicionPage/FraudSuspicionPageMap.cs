namespace CRMUITests.Pages.Applicaton.FraudSuspicionPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class FraudSuspicionPage
    {
        public IWebElement IsFraud
        {
            get
            {
                return this.FindElement(By.Name("suspected-fraud-checkbox"));
            }
        }

        public SelectElement Reason
        {
            get
            {
                return new SelectElement(this.FindElement(By.Name("suspicion-reason-dropdown")));
            }
        }

        public IWebElement Comment
        {
            get
            {
                return this.FindElement(By.Id("comment"));
            }
        }

        public IWebElement Send
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Изпрати апликацията')]"));
            }
        }

        public IWebElement SendMessages
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Успешно изпращане')]"));
            }
        }
    }
}
