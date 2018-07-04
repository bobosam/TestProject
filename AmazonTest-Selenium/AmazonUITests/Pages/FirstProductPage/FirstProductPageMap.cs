// <copyright file="FirstProductPageMap.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace AmazonUITests.Pages.FirstProductPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// Partial clas FirstProductPage inherit BasePage. 
    /// Contains all FirstProductPage elements mapping.
    /// </summary>
    public partial class FirstProductPage
    {
        /// <summary>
        /// Gets property contains web element for quantity.
        /// </summary>
        /// <value>Quantity web element.</value>
        private SelectElement Quantity
        {
            get
            {
                return new SelectElement(this.FindElementBy(By.Id("quantity")));
            }
        }

        /// <summary>
        /// Gets property contains web element for add to car button.
        /// </summary>
        /// <value>Button web element - AddToCar.</value>
        private IWebElement AddToCartButton
        {
            get
            {
                return this.FindElementBy(By.Id("add-to-cart-button"));
            }
        }

        /// <summary>
        /// Gets property contains web element for product title.
        /// </summary>
        /// <value>Product title web element.</value>
        private IWebElement ProductTitle
        {
            get
            {
                return this.FindElementBy(By.Id("productTitle"));
            }
        }

        /// <summary>
        /// Gets property contains web element for product price.
        /// </summary>
        /// <value>Product price web element.</value>
        private IWebElement ProductPrice
        {
            get
            {
                return this.FindElementBy(By.Id("priceblock_ourprice"));
            }
        }
    }
}
