// <copyright file="ShoppingCartPageMap.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace AmazonUITests.Pages.ShoppingCartPage
{
    using OpenQA.Selenium;

    /// <summary>
    /// Partial clas ShoppingCartPage inherit BasePage. 
    /// Contains all ShoppingCartPage elements mapping.
    /// </summary>
    public partial class ShoppingCartPage
    {
        /// <summary>
        /// Gets property contains button web element for open cart.
        /// </summary>
        /// <value>Button web element.</value>
        private IWebElement ViewCartButton
        {
            get
            {
                return this.FindElementBy(By.Id("hlb-view-cart-announce"));
            }
        }

        /// <summary>
        /// Gets property contains a text web element for the product title.
        /// </summary>
        /// <value>Text web element.</value>
        private IWebElement ProductTitle
        {
            get
            {
                return this.FindElementBy(By.XPath("//*[@id='activeCartViewForm']/div[2]/div/div[4]/div/div[1]/div/div/div[2]/ul/li[1]/span/a/span"));
            }
        }

        /// <summary>
        /// Gets property contains a text web element for the price.
        /// </summary>
        /// <value>Text web element.</value>
        private IWebElement Price
        {
            get
            {
                return this.FindElementBy(By.XPath("//*[@id='activeCartViewForm']/div[2]/div/div[4]/div/div[2]/p/span"));
            }
        }

        /// <summary>
        /// Gets property contains a text web element for the total price.
        /// </summary>
        /// <value>Text web element.</value>
        private IWebElement SubtotalPrice
        {
            get
            {
                return this.FindElementBy(By.XPath("//span[@id = 'sc-buy-box-ptc-button']/../..//span[contains(text(),'Subtotal (')]/../span[2]"));
            }
        }

        /// <summary>
        /// Gets property contains a text web element for the total price.
        /// </summary>
        /// <value>Text web element.</value>
        private IWebElement SubtotalText
        {
            get
            {
                return this.FindElementBy(By.XPath("//span[@id = 'sc-buy-box-ptc-button']/../..//span[contains(text(),'Subtotal (')]"));
            }
        }
    }
}
