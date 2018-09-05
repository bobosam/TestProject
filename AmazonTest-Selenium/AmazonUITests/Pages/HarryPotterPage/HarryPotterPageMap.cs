// <copyright file="HarryPotterPageMap.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace AmazonUITests.Pages.HarryPotterPage
{
    using OpenQA.Selenium;

    /// <summary>
    /// Partial clas HarryPotterPage inherit BasePage. 
    /// Contains all HarryPotterPage elements mapping.
    /// </summary>
    public partial class HarryPotterPage
    {
        /// <summary>
        /// Gets property contains web element for button open all departments.
        /// </summary>
        /// <value>All departments web element.</value>
        private IWebElement SeeAllDepartments
        {
            get
            {
                return this.FindElementBy(By.XPath("//*[@id='leftNavContainer']//a//span[contains(., 'See All')]"));
            }
        }

        /// <summary>
        /// Gets property contains web element for low price filter.
        /// </summary>
        /// <value>Input web element.</value>
        private IWebElement LowPrice
        {
            get
            {
                return this.FindElementBy(By.CssSelector("#low-price"));
            }
        }

        /// <summary>
        /// Gets property contains web element for max price filter.
        /// </summary>
        /// <value>Input web element.</value>
        private IWebElement MaxPrice
        {
            get
            {
                return this.FindElementBy(By.Id("high-price"));
            }
        }

        /// <summary>
        /// Gets property contains web element for submit min and max price filter.
        /// </summary>
        /// <value>Submit button web element.</value>
        private IWebElement PriceSubmit
        {
            get
            {
                return this.FindElementBy(By.XPath("//*[@id='low-price']/../span/span/input"));
            }
        }

        /// <summary>
        /// Gets property contains web element for check min age.
        /// </summary>
        /// <value>Check button web element.</value>
        private IWebElement Age14Years
        {
            get
            {
                return this.FindElementBy(By.Name("s-ref-checkbox-5442388011"));
            }
        }

        /// <summary>
        /// Gets property contains web element first product after filtering.
        /// </summary>
        /// <value>The first product in the list.</value>
        private IWebElement FirstResult
        {
            get
            {
                return this.FindElementBy(By.XPath("//*[@id='result_0']/div/div[4]/div/a/h2"));
            }
        }

        /// <summary>
        /// Category method return by string input element for choice this category.
        /// </summary>
        /// <param name="category">Input category.</param>
        /// <returns>Elements for category.</returns>
        private IWebElement Category(string category)
        {
            string xpath = string.Format($"//*[@id='leftNavContainer']//a//h4[contains(., '{category}')]");

            return this.FindElementBy(By.XPath(xpath));
        }
    }
}
