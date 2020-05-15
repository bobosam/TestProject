namespace CRMUITests.Pages.Applicaton.OtherCreditsPage
{
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class OtherCreditsPage
    {
        public IWebElement AddCredit
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), '+ Добави кредит')]"));
            }
        }

        public List<SelectElement> Creditors
        {
            get
            {
                List<SelectElement> creditorsSelects = new List<SelectElement>();
                List<IWebElement> creditors = new List<IWebElement>(this.FindElements(By.XPath("//select[contains(@id, 'creditor')]")));
                foreach (var creditor in creditors)
                {
                    SelectElement element = new SelectElement(creditor);
                    creditorsSelects.Add(element);
                }

                return creditorsSelects;
            }
        }

        public List<IWebElement> Amounts
        {
            get
            {
                List<IWebElement> amounts = new List<IWebElement>(this.FindElements(By.XPath("//input[contains(@id, 'otherLoanAmount')]")));

                return amounts;
            }
        }

        public List<IWebElement> Rates
        {
            get
            {
                List<IWebElement> rates = new List<IWebElement>(this.FindElements(By.XPath("//input[contains(@id, 'otherLoanRate')]")));

                return rates;
            }
        }

        public List<IWebElement> RemainingRefundsCounts
        {
            get
            {
                List<IWebElement> remainingRefundsCounts = new List<IWebElement>(this.FindElements(By.XPath("//input[contains(@id, 'otherRemainingRefundsCount')]")));

                return remainingRefundsCounts;
            }
        }

        public List<IWebElement> OtherLoanPayments
        {
            get
            {
                List<IWebElement> otherLoanPayments = new List<IWebElement>(this.FindElements(By.XPath("//input[contains(@id, 'otherLoanPayment')]")));

                return otherLoanPayments;
            }
        }

        public List<SelectElement> CreditsType
        {
            get
            {
                List<SelectElement> creditsType = new List<SelectElement>();
                List<IWebElement> credits = new List<IWebElement>(this.FindElements(By.XPath("//*[contains(@id, 'otherLoanLoanTypeId')]/div/div[1]/select")));
                foreach (var credit in credits)
                {
                    SelectElement element = new SelectElement(credit);
                    creditsType.Add(element);
                }

                return creditsType;
            }
        }

        public SelectElement CreditType
        {
            get
            {
                return new SelectElement(this.FindElement(By.CssSelector("#page-content-wrapper > div > div > div > app-applications > app-application-form > div > div.col-sm-10.mygrid-wrapper-div-content > div:nth-child(6) > div > app-client-indebtedness > div:nth-child(12) > div > div > div > div > div > div:nth-child(8) > select")));
            }
        }

        public IWebElement Distraint
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Запор')]"));
            }
        }

        public IWebElement Refinansing
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Рефинансиране')]"));
            }
        }

        public IWebElement CheckCredits
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Въведените външни кредити са актуални към момента')]"));
            }
        }
    }
}
