namespace BaseUITests.Pages.LoginPage
{
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class LoginPage
    {
        public void AssertValidUser()
        {
            Thread.Sleep(2000);
            Assert.AreEqual(BaseConstants.CRMHomePageUrl, this.Driver.Url);
        }

        public void AssertInvalidUser()
        {
            Assert.AreEqual("Грешно потребителско име или парола!", this.WrongData.Text);
        }
    }
}
