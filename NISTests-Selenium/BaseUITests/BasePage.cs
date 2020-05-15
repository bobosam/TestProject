namespace BaseUITests
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(10));
        }

        public IWebDriver Driver
        {
            get
            {
                return this.driver;
            }
        }

        public WebDriverWait Wait
        {
            get
            {
                return this.wait;
            }
        }

        public void Type(IWebElement element, string text)
        {
            Thread.Sleep(500);
            if (text == null)
            {
                text = string.Empty;
            }

            element.Clear();
            element.SendKeys(text.Trim());
        }

        public IWebElement FindElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(60));
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));

            return element;
        }

        public IList<IWebElement> FindElements(By by)
        {
            WebDriverWait wait = new WebDriverWait(this.driver, TimeSpan.FromSeconds(30));
            IList<IWebElement> elements = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(by));

            return elements;
        }

        public void SelectByText(SelectElement element, string text)
        {
            Thread.Sleep(750);
            element.SelectByText(text);
        }

        public void SelectByValue(SelectElement element, string text)
        {
            Thread.Sleep(500);
            element.SelectByValue(text);
        }

        public void AssertElementIsSelected(IWebElement element)
        {
            Thread.Sleep(500);
            Assert.IsTrue(element.Selected);
        }

        public void AssertDisabledElement(IWebElement element)
        {
            Thread.Sleep(500);
            Assert.AreEqual(false, element.Enabled);
        }

        public void AssertEnabledElement(IWebElement element)
        {
            Assert.IsTrue(element.Enabled);
        }

        public void ClicableSelectByText(SelectElement element, string text, IWebDriver driver)
        {
            Thread.Sleep(500);
            element.SelectByText(text);
            Thread.Sleep(500);
            var xpath = string.Format("//li/span[contains(text(), '{0}')]", text);
            Thread.Sleep(500);
            var currentElement = driver.FindElement(By.XPath(xpath));
            Thread.Sleep(500);
            currentElement.Click();
        }
    }
}
