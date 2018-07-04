// <copyright file="HomePageMap.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace AmazonUITests.Pages.HomePage
{
    using OpenQA.Selenium;

    /// <summary>
    /// Partial clas HomePage inherit BasePage. 
    /// Contains all HomePage elements mapping.
    /// </summary>
    public partial class HomePage
    {
        /// <summary>
        /// Gets property contains input web element for search.
        /// </summary>
        /// <value>Input web element.</value>
        private IWebElement SearchInputField
        {
            get
            {
                return this.FindElementBy(By.Id("twotabsearchtextbox"));
            }
        }

        /// <summary>
        /// Gets property contains button web element for submit search.
        /// </summary>
        /// <value>Button web element.</value>
        private IWebElement SearchButton
        {
            get
            {
                return this.FindElementBy(By.Id("nav-search-submit-text"));
            }
        }
    }
}
