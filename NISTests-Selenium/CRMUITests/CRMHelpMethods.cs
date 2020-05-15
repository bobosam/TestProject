namespace CRMUITests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;

    public class CRMHelpMethods
    {
        internal static bool IsEditable(IWebElement element)
        {
            try
            {
                element.Clear();
            }
            catch (InvalidElementStateException)
            {
                return false;
            }

            return true;
        }             
    }
}
