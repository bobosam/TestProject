namespace CRMUITests.Pages.Offer.AutoOfferPage
{
    using System.Threading;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;

    public partial class AutoOfferPage
    {
        internal void AssertPidValidation()
        {
            Thread.Sleep(750);

            bool con = false;

            foreach (var msg in this.Alerts)
            {
                if (msg.Text.Equals("Невалидно егн!") || msg.Text.Equals("Въведи коректно ЕГН на СД!") || msg.Text.Equals("Проблем с ЕГН на клиент."))
                {
                    con = true;
                    break;
                }
            }

            Assert.IsTrue(con);
        }

        internal void AssertOfferRemoved(string offerType)
        {
            Assert.IsFalse(this.Driver.PageSource.Contains(offerType), "Offer " + offerType + " not removed");
        }

        internal void AssertOfferTypeExist(string offerType)
        {
            Assert.IsTrue(FindElement(By.XPath(string.Format("//*[@id='offers-table']//*[contains(text(),'{0}')]/../..//button[contains(text(),'Премахни')]", offerType))).Displayed);
        }
    }
}
