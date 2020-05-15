namespace CRMUITests.Pages.Applicaton
{
    using System.Threading;
    using OpenQA.Selenium;
    using BaseUITests;
    using System.Linq;

    public partial class ApplicationMainPage : BasePage
    {
        public ApplicationMainPage(IWebDriver driver) : base(driver)
        {
        }

        public void SaveAndContiunueTab()
        {
            Thread.Sleep(500);
            this.SaveAndContinueButton.Click();
        }

        public void GoBack()
        {
            Thread.Sleep(500);
            this.Back.Click();
        }

        public void SaveAndContiunueGoBackSaveAndContiunue()
        {
            this.SaveAndContiunueTab();
            Thread.Sleep(1500);
            this.GoBack();
            Thread.Sleep(1500);
            this.SaveAndContiunueTab();
            Thread.Sleep(1500);
        }

        public void Refreshe()
        {
            Thread.Sleep(1000);
            this.Back.Click();
            Thread.Sleep(1000);
            this.SaveAndContinueButton.Click();
        }

        public void RefresheWithYes()
        {
            Thread.Sleep(1000);
            this.Back.Click();
            Thread.Sleep(1000);
            this.BackYes.Click();
            Thread.Sleep(1000);
            this.SaveAndContinueButton.Click();
        }

        //internal void SaveAndContiunueGoBackSaveAndContiunueFromCredits(OtherCreditsPage.OtherCreditsPage creditsPage)
        //{
        //    this.SaveAndContiunueTab();
        //    Thread.Sleep(2000);
        //    this.GoBack();
        //    Thread.Sleep(2000);
        //    creditsPage.CheckCredits.Click();
        //    this.SaveAndContiunueTab();
        //}

        internal void OpenNewApplication()
        {
            this.NewApplication.Click();
        }
    }
}
