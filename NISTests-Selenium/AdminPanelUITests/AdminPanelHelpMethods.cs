namespace AdminPanelUITests
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using System.Threading;

    public class AdminPanelHelpMethods
    {
        public static void RightClick(IWebElement element, IWebDriver driver)
        {
            Actions action = new Actions(driver).ContextClick(element);
            action.Build().Perform();
        }

        public static void MoovToElement(IWebElement element, IWebDriver driver)
        {
            Thread.Sleep(500);
            Actions action = new Actions(driver);
            action.MoveToElement(element).Perform();
        }      
    }
}
