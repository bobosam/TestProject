// <copyright file="ShoppingCartPage.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace AmazonUITests.Pages.ShoppingCartPage
{
    using BaseUITests;
    using OpenQA.Selenium;

    /// <summary>
    /// Partial clas ShoppingCartPage inherit BasePage. 
    /// Contains all ShoppingCartPage methods.
    /// </summary>
    public partial class ShoppingCartPage : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShoppingCartPage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver.</param>
        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// OpenShoppingCart method clicks to button and open shopping cart.
        /// </summary>
        public void OpenShoppingCart()
        {
            this.ViewCartButton.Click();
        }
    }
}
