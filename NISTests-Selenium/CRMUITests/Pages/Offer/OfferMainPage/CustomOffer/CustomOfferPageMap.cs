namespace CRMUITests.Pages.Offer.CustomOfferPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class CustomOfferPage
    {       
        private IWebElement ToCustomOffers
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Ръчно Офериране')]/../button[contains(text(),'Към оферти')]"));
            }
        }

        #region Offer One
        private SelectElement Product_OfferOne
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("product-select-first")));
            }
        }

        private SelectElement LoanAmount_OfferOne
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("amount-first")));
            }
        }

        private SelectElement Rate_OfferOne
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("period-first")));
            }
        }

        private IWebElement Payment_OfferOne
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'ОФЕРТА 1')]/..//*[contains(text(),'Месечна вноска:')]/../span"));
            }
        }

        private IWebElement PrintSEF_OfferOne
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'ОФЕРТА 1')]/..//button[contains(text(),'Принтирай СЕФ')]"));
            }
        }

        private IWebElement Accept_OfferOne
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'ОФЕРТА 1')]/..//button[contains(text(),'Приеми оферта')]"));
            }
        }

        #endregion
        #region Offer Two
        private SelectElement Product_OfferTwo
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("product-select-second")));
            }
        }

        private SelectElement LoanAmount_OfferTwo
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("amount-second")));
            }
        }

        private SelectElement Rate_OfferTwo
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("period-second")));
            }
        }

        private IWebElement Payment_OfferTwo
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'ОФЕРТА 2')]/..//*[contains(text(),'Месечна вноска:')]/../span"));
            }
        }

        private IWebElement PrintSEF_OfferTwo
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'ОФЕРТА 2')]/..//button[contains(text(),'Принтирай СЕФ')]"));
            }
        }

        private IWebElement Accept_OfferTwo
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'ОФЕРТА 2')]/..//button[contains(text(),'Приеми оферта')]"));
            }
        }

        #endregion
        #region Offer Three
        private SelectElement Product_OfferThree
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("product-select-third")));
            }
        }

        private SelectElement LoanAmount_OfferThree
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("amount-third")));
            }
        }

        private SelectElement Rate_OfferThree
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("period-third")));
            }
        }

        private IWebElement Payment_OfferThree
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'ОФЕРТА 3')]/..//*[contains(text(),'Месечна вноска:')]/../span"));
            }
        }

        private IWebElement PrintSEF_OfferThree
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'ОФЕРТА 3')]/..//button[contains(text(),'Принтирай СЕФ')]"));
            }
        }

        private IWebElement Accept_OfferThree
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'ОФЕРТА 3')]/..//button[contains(text(),'Приеми оферта')]"));
            }
        }

        #endregion

        private IWebElement PendingDecision
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(),'Кредитоискателят ще обмисли офертата')]"));
            }
        }

        private IWebElement RejectOffers
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(),'Кредитоискателят отказва офертата')]"));
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
    }
}
