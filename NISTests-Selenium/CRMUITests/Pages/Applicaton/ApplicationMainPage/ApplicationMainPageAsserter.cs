namespace CRMUITests.Pages.Applicaton
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;

    public partial class ApplicationMainPage
    {
        public void AssertApplicationStep()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asserts that the current page is correct.
        /// </summary>
        public void AssertApplicationPage(string page)
        {
            Assert.IsTrue(this.Driver.PageSource.Contains(page), "Wrong page. The page have to contains " + page);
        }

        /// <summary>
        /// Asserts no alerts are displayed unnecessary or inadequate.
        /// </summary>
        internal void AssertNoWarningMsg()
        {
            Assert.IsTrue(this.WarningMsg.Count == 0, "Неадекватна валидация" + this.WarningMsg.ToString());
        }

        /// <summary>
        /// Assetrts alerts are displayed. Expect > 0.
        /// </summary>
        internal void AssertWarningMsgAppear()
        {
            Assert.IsTrue(this.WarningMsg.Count > 0, "Липсва валидация");
        }

        public void AssertDisabledSaveAndContinueButton()
        {
            this.AssertDisabledElement(this.SaveAndContinueButton);
        }

        public void AsserEnabledSaveAndContinueButton()
        {
            this.AssertEnabledElement(this.SaveAndContinueButton);
        }
    }
}
