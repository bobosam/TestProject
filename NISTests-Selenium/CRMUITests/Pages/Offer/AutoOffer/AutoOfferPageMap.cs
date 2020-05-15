namespace CRMUITests.Pages.Offer.AutoOfferPage
{
    using System.Collections.Generic;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class AutoOfferPage
    {
        #region Check PID

        private IWebElement ClientForeigner
        {
            get
            {
                return this.FindElement(By.Name("isClientForeigner"));
            }
        }

        private IWebElement ClientPID
        {
            get
            {
                return this.FindElement(By.Id("clientPid"));
            }
        }

        private IWebElement HasCodebtor
        {
            get
            {
                return this.FindElement(By.Name("hasCoDebtor"));
            }
        }

        private IWebElement JDForeigner
        {
            get
            {
                return this.FindElement(By.Name("coDebtor-foreigner"));
            }
        }

        private IWebElement JDPID
        {
            get
            {
                return this.FindElement(By.Name("coDebtorPid"));
            }
        }

        private IWebElement Check
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(),'Провери')]"));
            }
        }

        private IWebElement ToAutoOffer
        {
            get
            {
                return this.FindElement(By.XPath("//div[1]/*[contains(text(),'Офериране')]/../button[contains(text(),'Към оферти')]"));
            }
        }

        #endregion

        #region Client fields

        public IWebElement JDisForeigner
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-coDebtor-foreigner"));
            }
        }

        public IWebElement JDAge
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-coDebtor-age"));
            }
        }

        public IWebElement JDFirstName
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input--coDebtorname"));
            }
        }

        public IWebElement JDSecondName
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-coDebtor-middle-name"));
            }
        }

        public IWebElement JDLastName
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-coDebtor-last-name"));
            }
        }

        public IWebElement JDPhone
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-coDebtor-phone"));
            }
        }

        private IWebElement RequeredPayment
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-monthly-payment"));
            }
        }

        private IWebElement RequeredAmount
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-credit-amount"));
            }
        }

        private SelectElement RequeredRate
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("client-offering-input-credir-duration")));
            }
        }

        private IWebElement TotalIncomes
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-total-income"));
            }
        }

        private IWebElement HasUnofficialIncomes
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-unofficial-income"));
            }
        }

        private IWebElement OtherIncomes
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-total-other-income"));
            }
        }

        private IWebElement TotalDebts
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-total-mothly-payments"));
            }
        }

        private IWebElement TotalExpenses
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-total-expenses"));
            }
        }

        private IWebElement CurrentWorkingTime
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-current-job-time-working"));
            }
        }

        private IWebElement IsForeigner
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-foreigner"));
            }
        }

        private IWebElement Age
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-age"));
            }
        }

        private IWebElement FirstName
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-name"));
            }
        }

        private IWebElement SecondName
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-middle-name"));
            }
        }

        private IWebElement LastName
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-last-name"));
            }
        }

        private IWebElement Phone
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-phone"));
            }
        }

        private IWebElement InternalRefinancing
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-internal-refinancing"));
            }
        }

        private IWebElement ExternalRefinancing
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-external-refinancing"));
            }
        }

        private IWebElement RefinancingRemainingDebt
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-external-refinancing-remaining-liability"));
            }
        }

        private IWebElement RefinancingMonthlyPayment
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-external-refinancing-remaining-liability"));
            }
        }

        #endregion

        #region JD fields

        private IWebElement JDTotalIncomes
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-coDebtor-official-income"));
            }
        }

        private IWebElement JDTotalDebts
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-coDebtor-total-mothly-payments"));
            }
        }

        private IWebElement JDTotalExpenses
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-coDebtor-total-expenses"));
            }
        }

        private IWebElement JDCurrentWorkingTime
        {
            get
            {
                return this.FindElement(By.Id("client-offering-input-coDebtor-current-job-time-working"));
            }
        }

               #endregion

        public IWebElement Calculate
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(),'ИЗЧИСЛИ')]"));
            }
        }

        public IWebElement NoData
        {
            get
            {
                return this.FindElement(By.Id("no-data"));
            }
        }

        #region Returned Offers

        public IWebElement WithPackage
        {
            get
            {
                return this.FindElement(By.XPath("//input[@value='PackageCkeckBox']"));
            }
        }

        public IWebElement WithJD
        {
            get
            {
                return this.FindElement(By.XPath("//input[@value='CoDebtorCkeckBox']"));
            }
        }

        #endregion

        #region Upsell offer

        //private IWebElement UpsellGrid
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='offers - table']//*[contains(text(),'Upsell')]/../.."));
        //    }
        //}

        //private IWebElement UpsellProduct
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='offers - table']//*[contains(text(),'Upsell')]/../div[2]"));
        //    }
        //}

        //private IWebElement UpsellAmount
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='offers-table']//*[contains(text(),'Upsell')]/../../div[2]"));
        //    }
        //}

        //private IWebElement UpsellRate
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='offers-table']//*[contains(text(),'Upsell')]/../../div[3]"));
        //    }
        //}

        //private IWebElement Upsellpayment
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='offers-table']//*[contains(text(),'Upsell')]/../../div[4]"));
        //    }
        //}

        //private IWebElement UpsellTotalAmount
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='offers-table']//*[contains(text(),'Upsell')]/../../div[5]"));
        //    }
        //}

        //private IWebElement UpsellAccept
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='offers-table']//*[contains(text(),'Upsell')]/../..//button[contains(text(),'Приеми')]"));
        //    }
        //}

        //private IWebElement UpsellPrintSEF
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='offers-table']//*[contains(text(),'Upsell')]/../..//button[contains(text(),'Принтирай')]"));
        //    }
        //}

        //private IWebElement UpsellRemove
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='offers-table']//*[contains(text(),'Upsell')]/../..//button[contains(text(),'Премахни')]"));
        //    }
        //}

        #endregion
        private IWebElement PendingDecision
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(),'Кредитоискателят ще обмисли офертите')]"));
            }
        }

        private IWebElement RejectOffers
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(),'Кредитоискателят отказва офертите')]"));
            }
        }

        private SelectElement SelectReasonRejection
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("rejection-reason")));
            }
        }

        private IWebElement Ok
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(),'OK')]"));
            }
        }

        private List<IWebElement> Alerts
        {
            get
            {
                return new List<IWebElement>(this.FindElements(By.XPath("//*[@class='alert alert-danger']")));
            }
        }
    }
}