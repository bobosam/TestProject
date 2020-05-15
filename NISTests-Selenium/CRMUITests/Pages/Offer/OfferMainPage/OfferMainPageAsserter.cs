namespace CRMUITests.Pages.Offer.OfferMainPage
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BaseUITests;

    public partial class OfferMainPage
    {
        internal void AssertMainPage()
        {
            Assert.IsTrue(this.Driver.Url.Equals(BaseConstants.TestCRMUrl + "/#/offers/main-screen"), "Wrong page. Must be Main Offers Page, but it is not.");
        }

        internal void AssertNewOfferPage()
        {
            Assert.IsTrue(this.Driver.Url.Equals(BaseConstants.TestCRMUrl + "/#/offers/offering-form/choose-offer-type"), "Wrong page. Must be New Offer Page, but it is not.");
        }

        internal void AssertCustomOfferPage()
        {
            Assert.IsTrue(this.Driver.Url.Equals(BaseConstants.TestCRMUrl + "/#/offers/offering-form/manual-offer"), "Wrong page. Must be Manual/Custom Offer Page, but it is not.");
        }

        internal void AssertAutoOfferPage()
        {
            Assert.IsTrue(this.Driver.Url.Equals(BaseConstants.TestCRMUrl + "/#/offers/offering-form/automatic-offer"), "Wrong page. Must be Auto Offer Page, but it is not.");
        }

        internal void AssertRejectionPage()
        {
            Assert.IsTrue(this.Driver.Url.Equals(BaseConstants.TestCRMUrl + "/#/offers/offering-form/rejection"), "Wrong page. Must be Rejection Offer Page, but it is not.");
        }      
    }
}
