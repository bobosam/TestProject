// <copyright file="FirstProductPage.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace AmazonUITests.Pages.FirstProductPage
{
    using System.Collections.Generic;
    using System.Threading;

    using BaseUITests;
    using OpenQA.Selenium;

    /// <summary>
    /// Partial clas FirstProductPage inherit BasePage. 
    /// Contains all FirstProductPage methods.
    /// </summary>
    public partial class FirstProductPage : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FirstProductPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver.</param>
        public FirstProductPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// AddToCart selects a purchased quantity and submit data..
        /// </summary>
        /// <param name="count">Purchased quantity.</param>
        public void AddToCart(string count)
        {
            this.Quantity.SelectByText(count);
            this.AddToCartButton.Click();
        }

        /// <summary>
        /// GetProductData gets a product title and product price and saves them.
        /// </summary>
        /// <returns>List purchased data.</returns>
        public List<string> GetProductData()
        {
            Thread.Sleep(3000);
            var productData = new List<string>();

            string title = this.ProductTitle.Text.Trim();
            string price = this.ProductPrice.Text.Trim('$');

            productData.Add(title);
            productData.Add(price);

            return productData;
        }
    }
}
