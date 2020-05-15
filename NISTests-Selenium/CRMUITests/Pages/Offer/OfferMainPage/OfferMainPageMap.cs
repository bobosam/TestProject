namespace CRMUITests.Pages.Offer.OfferMainPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class OfferMainPage
    {
        public IWebElement NewOffer
        {
            get
            {
                return this.FindElement(By.XPath("//img[contains(@src,'assets/images/add.png')]/.."));
            }
        }

        private SelectElement ReasonForRejection
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("rejection-reason")));
            }
        }

        private SelectElement OkRejectionReason
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//button[contains(text(),'OK')]")));
            }
        }

        #region Search

        private IWebElement StateMultiselect
        {
            get
            {
                return this.FindElement(By.CssSelector("div.ui-multiselect-label-container"));
            }
        }

        private IWebElement FromDate
        {
            get
            {
                return this.FindElement(By.XPath("//*[@placeholder='От:']//input"));
            }
        }

        private IWebElement ToDate
        {
            get
            {
                return this.FindElement(By.XPath("//*[@placeholder='До:']//input"));
            }
        }

        private IWebElement SearchField
        {
            get
            {
                return this.FindElement(By.XPath("//input[@placeholder='Търсене']"));
            }
        }

        private IWebElement SearchButton
        {
            get
            {
                return this.FindElement(By.XPath("//div//*[contains(text(),'search')]"));
            }
        }

        private IWebElement AdditionalSearch
        {
            get
            {
                return this.FindElement(By.XPath("//div//*[contains(text(),'Подробно търсене')]/../span"));
            }
        }

        private SelectElement HasRefinancig
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("has-refinancing")));
            }
        }

        private SelectElement HasCodebtor
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("has-codebtor")));
            }
        }

        private IWebElement SearchFieldAdvanced
        {
            get
            {
                return this.FindElement(By.Id("credit-expert"));
            }
        }
        private SelectElement Region
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("region")));
            }
        }
        private SelectElement Area
        {
            get
            {
                return new SelectElement(this.FindElement(By.Name("area")));
            }
        }
        private SelectElement SubArea
        {
            get
            {
                return new SelectElement(this.FindElement(By.Name("subarea")));
            }
        }
#endregion

    }
}
