namespace CRMUITests.Pages.Applicaton.FraudSuspicionPage
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class FraudSuspicionPage
    {
        public void AssertForSending()
        {
            Assert.AreEqual("Успешно изпращане", this.SendMessages.Text);
        }
    }
}
