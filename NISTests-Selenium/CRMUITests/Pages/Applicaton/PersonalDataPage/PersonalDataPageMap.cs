namespace CRMUITests.Pages.Applicaton.PersonalDataPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class PersonalDataPage
    {
        public IWebElement FirstName
        {
            get
            {
                return this.FindElement(By.Id("firstName"));
            }
        }

        public IWebElement SecondName
        {
            get
            {
                return this.FindElement(By.Id("secondName"));
            }
        }

        public IWebElement LastName
        {
            get
            {
                return this.FindElement(By.Id("lastName"));
            }
        }

        public IWebElement Pid
        {
            get
            {
                return this.FindElement(By.Id("pid"));
            }
        }

        public IWebElement BirthDate
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='bithDate']/span/input"));
            }
        }

        public IWebElement Gender
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='gender']/div/label"));
            }
        }

        public IWebElement IsForeigner
        {
            get
            {
                return this.FindElement(By.Id("isForeigner"));
            }
        }

        public SelectElement PersonType
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='PersonTypeCode']/div/div[1]/select")));
            }
        }

        public IWebElement IdCardNumber
        {
            get
            {
                return this.FindElement(By.Id("cardNumber"));
            }
        }

        public IWebElement CardCreationDate
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='IdCardIssueDate']/span/input"));
            }
        }

        public IWebElement CardExpirationDate
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='IdCardDateOfExpiry']/span/input"));
            }
        }

        public IWebElement CardIssuer
        {
            get
            {
                return this.FindElement(By.XPath("//p-autocomplete/span/input"));
            }
        }

        public IWebElement CardIssuerSearch
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='identityCardIssuer']/div/div[4]/div[1]/input"));
            }
        }

        public IWebElement CardIssuerResultFirst
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='identityCardIssuer']/div/div[4]/div[2]/ul/li[2]"));
            }
        }

        public IWebElement ExceptionMessageCyrilik
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Моля, пишете на кирилица!')]"));
            }
        }

        public IWebElement ExceptionMessageWrongNumber
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Невалиден номер!')]"));
            }
        }

        public IWebElement ExceptionMessageWrongDate
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Датата е невалидна!')]"));
            }
        }

        public IWebElement ExceptionMissingData
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Полето е задължително!')]"));
            }
        }

        public override IWebElement SaveAndContinueButton
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Запиши и продължи')]"));
            }
        }
    }
}
