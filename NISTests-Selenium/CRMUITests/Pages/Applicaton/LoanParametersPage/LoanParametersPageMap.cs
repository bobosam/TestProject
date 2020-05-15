namespace CRMUITests.Pages.Applicaton.LoanParametersPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class LoanParametersPage
    {
        private IWebElement Pid
        {
            get
            {
                return this.FindElement(By.Id("pid"));
            }
        }

        private IWebElement WrongPidMessage
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='pid']/../div"));
            }
        }

        private IWebElement MissingPidMessage
        {
            get
            {
                return this.FindElement(By.XPath("//div[contains(text(), 'Полето е задължително!')]"));
            }
        }

        private SelectElement ProductType
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='productType']/div/div[1]/select")));
            }
        }

        private SelectElement LoanAmount
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='Amount']/div/div[1]/select")));
            }
        }

        private SelectElement LoanRate
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='Term']/div/div[1]/select")));
            }
        }

        private IWebElement MonthlyAmount
        {
            get
            {
                return this.FindElement(By.Id("payment"));
            }
        }

        private SelectElement PaymentDate
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='PaymentDayId']/div/div[1]/select")));
            }
        }

        private SelectElement LoanPurpose
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='loanPurpose']/div/div[1]/select")));
            }
        }

        private SelectElement RequestSource
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='contactSources']/div/div[1]/select")));
            }
        }
    }
}
