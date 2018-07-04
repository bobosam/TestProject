// <copyright file="BasePage.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace BaseUITests
{
    using System;
    using System.Collections.Generic;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    /// <summary>
    /// BasePage contains all general page methods.
    /// </summary>
    public class BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BasePage"/> class.
        /// </summary>
        /// <param name="driver">Selenium web driver.</param>
        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
        }

        /// <summary>
        /// Gets or sets property contains driver.
        /// </summary>
        /// <value>The driver instance.</value>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// Gets or sets property contains wait.
        /// </summary>
        /// <value>The wait instance.</value>
        public WebDriverWait Wait { get; set; }

        /// <summary>
        /// Type method clean the element and fill the text.
        /// </summary>
        /// <param name="element">Input element.</param>
        /// <param name="text">Input text.</param>
        public void Type(IWebElement element, string text)
        {
            if (text == null)
            {
                text = string.Empty;
            }

            element.Clear();
            element.SendKeys(text.Trim());
        }

        /// <summary>
        /// FindElementBy method wait to view element and return him.
        /// </summary>
        /// <param name="by">Elements locator.</param>
        /// <returns>Web element.</returns>
        public IWebElement FindElementBy(By by)
        {
            IWebElement element = this.Wait.Until(drv => drv.FindElement(by));

            return element;
        }

        /// <summary>
        /// FindElementBy method wait to view elements and return list with web elements.
        /// </summary>
        /// <param name="by">Elements locator.</param>
        /// <returns>Web elements list.</returns>
        public IList<IWebElement> FindElementsBy(By by)
        {
            IList<IWebElement> elements = this.Wait.Until(drv => drv.FindElements(by));

            return elements;
        }
    }
}
