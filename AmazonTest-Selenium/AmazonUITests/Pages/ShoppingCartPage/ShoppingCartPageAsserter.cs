// <copyright file="ShoppingCartPageAsserter.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace AmazonUITests.Pages.ShoppingCartPage
{
    using System.Collections.Generic;

    using NUnit.Framework;

    /// <summary>
    /// Partial clas ShoppingCartPage inherit BasePage. 
    /// Contains all ShoppingCartPage assert methods.
    /// </summary>
    public partial class ShoppingCartPage
    {
        /// <summary>
        /// AssertShoppingCart calls AssertProductTitle, AssertPrice, AssertSubtotal and AssertQuantity methods.
        /// </summary>
        /// <param name="data">The saved product data list.</param>
        public void AssertShoppingCart(List<string> data)
         {
            this.AssertProductTitle(data[0]);
            this.AssertPrice(data[1]);
            this.AssertSubtotal(data[1], data[2]);
            this.AssertQuantity(data[2]);
        }

        /// <summary>
        /// Assert for purchased quantity.
        /// </summary>
        /// <param name="quantity">Purchased quantity.</param>
        private void AssertQuantity(string quantity)
        {
            var subtotal = string.Format($"Subtotal ({quantity} items):");
            var cardSubtotal = this.SubtotalText.Text.Trim();

            Assert.AreEqual(subtotal, cardSubtotal, "Quantity");
        }

        /// <summary>
        /// Assert for total price.
        /// </summary>
        /// <param name="priceString">Price as a string.</param>
        /// <param name="quantityString">Quantity as a string.</param>
        private void AssertSubtotal(string priceString, string quantityString)
        {
            var price = double.Parse(priceString);
            var quantity = int.Parse(quantityString);
            var total = string.Format($"{ price* quantity:F2}");

            var cardTotal = this.SubtotalPrice.Text.Trim().Trim('$');

            Assert.AreEqual(total, cardTotal, "Total");
        }

        /// <summary>
        /// Assert for product price.
        /// </summary>
        /// <param name="price">Price as a string.</param>
        private void AssertPrice(string price)
        {
            var cardPrice = this.Price.Text.Trim().Trim('$');

            Assert.AreEqual(price, cardPrice, "Price");
        }

        /// <summary>
        /// Assert for product title.
        /// </summary>
        /// <param name="title">Product title.</param>
        private void AssertProductTitle(string title)
        {
            Assert.AreEqual(title, this.ProductTitle.Text.Trim(), "Title");
        }
    }
}
