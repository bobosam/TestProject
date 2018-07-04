// <copyright file="ShoppingCartTests.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace AmazonUITests.UITests
{
    using BaseUITests;
    using DataDriven;
    using DataDriven.Models;
    using AmazonUITests.Pages.FirstProductPage;
    using AmazonUITests.Pages.HarryPotterPage;
    using AmazonUITests.Pages.HomePage;
    using AmazonUITests.Pages.ShoppingCartPage;
    using NUnit.Framework;

    /// <summary>
    /// ShoppingCartTests class inherit BaseTest and contains all test.
    /// </summary>
    [TestFixture]
    public class ShoppingCartTests : BaseTest
    {
        /// <summary>
        /// Contain all homepage elements, methods, and asserters.
        /// </summary>        
        private HomePage homePage;

        /// <summary>
        /// Contain all Hary Poter page elements, methods, and asserters.
        /// </summary>   
        private HarryPotterPage harryPotterPage;

        /// <summary>
        /// It contains all the elements, methods and assertions of the first product page.
        /// </summary>
        private FirstProductPage firstProductPage;

        /// <summary>
        /// It contains all the elements, methods and assertions of the shopping cart page.
        /// </summary>
        private ShoppingCartPage shoppingCartPage;

        /// <summary>
        /// TestInit provides a common set of functions 
        /// that are performed just before each test method is called.
        /// </summary>
        [SetUp]
        public void TestInit()
        {
            this.TestInitialize();
            this.homePage = new HomePage(this.Driver);
            this.harryPotterPage = new HarryPotterPage(this.Driver);
            this.firstProductPage = new FirstProductPage(this.Driver);
            this.shoppingCartPage = new ShoppingCartPage(this.Driver);
        }

        /// <summary>
        /// Test Method ShoppingCartTest downloads data from an Excel file, 
        /// filters the products on it, selects the first result and buys it.
        /// </summary>
        [Test]
        public void ShoppingCartTest()
        {
            var fileName = DataDrivenConstants.DatafileName;
            var searchString = AccessExcelData.GetTestData<Search>("TestName", "Default", "Search", fileName);
            var category = AccessExcelData.GetTestData<Category>("TestName", "Default", "Category", fileName);
            var price = AccessExcelData.GetTestData<Price>("TestName", "Default", "Price", fileName);
            var count = AccessExcelData.GetTestData<Count>("TestName", "Default", "Count", fileName);
           
            this.homePage.NavigateToHomePage(UITestsConstants.AmazonUrl);
            this.homePage.SearchByText(searchString.SearchString);
            this.harryPotterPage.FilteringItems(category.CurrentCategory, price.MinPrice, price.MaxPrice);

            var productData = this.firstProductPage.GetProductData();
            productData.Add(count.CurrentCount);

            this.firstProductPage.AddToCart(count.CurrentCount);
            this.shoppingCartPage.OpenShoppingCart();

            this.shoppingCartPage.AssertShoppingCart(productData);
        }
    }
}
