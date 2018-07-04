// <copyright file="HomePage.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace AmazonUITests.Pages.HomePage
{
    using BaseUITests;
    using OpenQA.Selenium;

    /// <summary>
    /// Partial clas HomePage inherit BasePage. 
    /// Contains all HomePage methods.
    /// </summary>
    public partial class HomePage : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver.</param>
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// NavigateToHomePage navigates to current URL.
        /// </summary>
        /// <param name="url">Home page url.</param>
        public void NavigateToHomePage(string url)
        {
            this.Driver.Navigate().GoToUrl(url);
        }

        /// <summary>
        /// SearchByText input search text and submit.
        /// </summary>
        /// <param name="searchString">Search text.</param>
        public void SearchByText(string searchString)
        {
            this.Type(this.SearchInputField, searchString);
            this.SearchButton.Submit();
        }
    }
}
