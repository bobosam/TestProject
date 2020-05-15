namespace CRMUITests.Pages.Offer.OfferMainPage
{
    using BaseUITests;
    using OpenQA.Selenium;
    using DataDriven.Models.CRM.Offer;
    using System.Collections.Generic;
    using System;
    using System.Text.RegularExpressions;

    public partial class OfferMainPage : BasePage
    {
        public OfferMainPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Type all criteria in Main and Advanced Search options.
        /// </summary>
        /// <param name="offer"></param>
        internal void SearchOffers(SearchOffer offer)
        {
            this.SelectMultiselect(offer);
            this.Type(this.FromDate, offer.FromDate);
            this.Type(this.ToDate, offer.Todate);
            this.Type(this.SearchField, offer.SearchField);
        }
        
        /// <summary>
        /// Open advanced search and select options. Doesn't click on Search button.
        /// </summary>
        /// <param name="offer"></param>
        internal void AdvancedSearch(SearchOffer offer)
        {
            this.AdditionalSearch.Click();
           
            this.SelectByText(this.HasRefinancig, offer.HasRefinancing);
            this.SelectByText(this.HasCodebtor, offer.HasCodebtor);
            this.Type(this.SearchFieldAdvanced, offer.SearchFieldAdvanced);

            try
            {
                this.SelectByText(this.Region, offer.Region);
                this.SelectByText(this.Area, offer.Area);
                this.SelectByText(this.SubArea, offer.SubArea);
            }
            catch (NoSuchElementException)
            {
            }
        }

        /// <summary>
        /// Select all options in Multiselect and close the dropdown.
        /// </summary>
        /// <param name="offer"></param>
        private void SelectMultiselect(SearchOffer offer)
        {
            string[] multi;
            string[] separators = { ",", ";" };
            multi = offer.State.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            this.StateMultiselect.Click();
            foreach (var option in multi)
            {
                this.FindElement(By.XPath(string.Format("//*[contains(text(), 'Приета')]/../div[1]", option))).Click();
            }
            this.StateMultiselect.Click();
        }

        /// <summary>
        /// Click on button search after criteria is set.
        /// </summary>
        internal void Search()
        {
            this.SearchButton.Click();
        }

        /// <summary>
        /// Return offer list result.
        /// </summary>
        internal void GetSearchResult()
        {
            //to do
        }
    }
}
