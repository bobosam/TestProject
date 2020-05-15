namespace CRMUITests.Pages.Applicaton.OtherIncomePage
{
    using OpenQA.Selenium;

    public partial class OtherIncomePage
    {
        public IWebElement AdditionalContracts
        {
            get
            {
                return this.FindElement(By.Id("AdditionalEmploymentContracts"));
            }
        }

        public IWebElement Rent
        {
            get
            {
                return this.FindElement(By.Id("Rent"));
            }
        }

        public IWebElement SupportMoney
        {
            get
            {
                return this.FindElement(By.Id("SupportMoney"));
            }
        }

        public IWebElement ChildMoney
        {
            get
            {
                return this.FindElement(By.Id("ChildMoney"));
            }
        }

        public IWebElement Transact
        {
            get
            {
                return this.FindElement(By.Id("TransactFromForeignCountry"));
            }
        }

        public IWebElement OtherGains
        {
            get
            {
                return this.FindElement(By.Id("OtherGains"));
            }
        }

        public IWebElement Comment
        {
            get
            {
                return this.FindElement(By.Id("Comment"));
            }
        }
    }
}
