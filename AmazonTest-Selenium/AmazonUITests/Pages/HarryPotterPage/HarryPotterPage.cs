// <copyright file="HarryPotterPage.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace AmazonUITests.Pages.HarryPotterPage
{
    using System.Threading;

    using BaseUITests;
    using OpenQA.Selenium;

    /// <summary>
    /// Partial clas HarryPotterPage inherit BasePage. 
    /// Contains all HarryPotterPage methods.
    /// </summary>
    public partial class HarryPotterPage : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HarryPotterPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver.</param>
        public HarryPotterPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// FilteringItems method filter products by input parameters.
        /// </summary>
        /// <param name="category">Input category.</param>
        /// <param name="minPrice">Input min price.</param>
        /// <param name="maxPrice">Input max price.</param>
        public void FilteringItems(string category, string minPrice, string maxPrice)
        {
            Thread.Sleep(2000);
            this.SeeAllDepartments.Click();
            this.Category(category).Click();

            Thread.Sleep(2000);
            this.Type(this.LowPrice, minPrice);
            this.Type(this.MaxPrice, maxPrice);
            this.PriceSubmit.Submit();

            this.Age14Years.Click();
            Thread.Sleep(3000);
            this.FirstResult.Click();
        }
    }
}
