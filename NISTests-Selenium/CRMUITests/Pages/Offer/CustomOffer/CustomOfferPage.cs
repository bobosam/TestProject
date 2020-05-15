namespace CRMUITests.Pages.Offer.CustomOfferPage
{
    using System.Threading;

    using DataDriven.Models.CRM.Offer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using BaseUITests;

    public partial class CustomOfferPage : BasePage
    {
        public CustomOfferPage(IWebDriver driver) : base(driver)
        {
        }

        internal void NavigateTo()
        {
            this.ToCustomOffers.Click();
        }

        internal void CreateCustomOfferOne(CustomOffer offer)
        {
            this.SelectByText(this.Product_OfferOne, offer.Product);
            this.SelectByText(this.LoanAmount_OfferOne, offer.LoanAmount);
            this.SelectByText(this.Rate_OfferOne, offer.Rate);
            Assert.IsTrue(this.Payment_OfferOne.Text.Equals(offer.Payment));
        }

        internal void CreateCustomOfferTwo(CustomOffer offer)
        {
            this.SelectByText(this.Product_OfferTwo, offer.Product);
            this.SelectByText(this.LoanAmount_OfferTwo, offer.LoanAmount);
            this.SelectByText(this.Rate_OfferTwo, offer.Rate);
            Assert.IsTrue(this.Payment_OfferTwo.Text.Equals(offer.Payment));
        }

        internal void CreateCustomOfferThree(CustomOffer offer)
        {
            this.SelectByText(this.Product_OfferThree, offer.Product);
            this.SelectByText(this.LoanAmount_OfferThree, offer.LoanAmount);
            this.SelectByText(this.Rate_OfferThree, offer.Rate);
            Assert.IsTrue(this.Payment_OfferThree.Text.Equals(offer.Payment));
        }

        internal void AcceptOfferOne()
        {
            this.Accept_OfferOne.Click();
        }

        internal void AcceptOfferTwo()
        {
            this.Accept_OfferTwo.Click();
        }

        internal void AcceptOfferThree()
        {
            this.Accept_OfferThree.Click();
        }

        internal void PrintSEFOfferOne()
        {
            this.PrintSEF_OfferOne.Click();
        }

        internal void PrintSEFOfferTwo()
        {
            this.PrintSEF_OfferTwo.Click();
        }

        internal void PrintSEFOfferThree()
        {
            this.PrintSEF_OfferThree.Click();
        }

        internal void RejectAllOffers()
        {
            this.RejectOffers.Click();
        }

        internal void RejectionReason(string reason)
        {
            this.SelectByText(this.SelectReasonRejection, reason);
            this.Ok.Click();
            Thread.Sleep(500);
        }

        internal void RethinkDecision()
        {
            this.PendingDecision.Click();
            Thread.Sleep(500);
        }
    }
}