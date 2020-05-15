namespace CRMUITests.Pages.Applicaton.LoanParametersPage
{
    using DataDriven.Models.CRM.Applicaton;
    using DataDriven.Models.CRM.Offer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using System.Threading;

    public partial class LoanParametersPage
    {
        public void AssertApplicationPage()
        {
            Thread.Sleep(1500);
            base.AssertApplicationPage("Параметри на кредита");
        }

        /// <summary>
        /// Asserts that monthly amount is fillout after product was chosen.
        /// </summary>
        public void AssertMonthlyAmountExist()
        {
            Thread.Sleep(1500);
            var text = this.MonthlyAmount.GetAttribute("value");
            Assert.IsFalse(text == string.Empty, "Monthly amount doesn't exist");
        }

        public void AssertAcceptedOfferParameters(CustomOffer offer)
        {
            Assert.IsTrue(this.ProductType.SelectedOption.GetAttribute("text").Equals(offer.Product), "Wrong Product. Must be " + offer.Product);
            Assert.IsTrue(this.LoanAmount.SelectedOption.GetAttribute("text").Equals(offer.LoanAmount), "Wrong Amount Must be " + offer.LoanAmount);
            Assert.IsTrue(this.LoanRate.SelectedOption.GetAttribute("text").Equals(offer.Rate), "Wrong Rate. Must be " + offer.Rate);
            Assert.IsTrue(this.MonthlyAmount.GetAttribute("value").Equals(offer.Payment), "Wrong Payment. Must be " + offer.Payment);
        }

        public void AssertWrongPid()
        {
            Assert.AreEqual("Невалидно ЕГН! Възрастта трябва да бъде по-висока от 18г", this.WrongPidMessage.Text);
        }


        public void AssertMissingPid()
        {
            Thread.Sleep(500);
            Assert.AreEqual("Полето е задължително!", this.MissingPidMessage.Text);
        }

        public void CheckSavedParameters(LoanParameters parameters)
        {
            Assert.IsFalse(this.ApplicationNumber.GetAttribute("value").ToString().Trim() == string.Empty, "Application Number");
            Assert.AreEqual("Недовършена", this.ApplicationStatus.GetAttribute("value"), "Application Status");
            Assert.AreEqual(this.Pid.GetAttribute("value").ToString().Trim(), parameters.Pid.Trim(), "ЕГН");
            Assert.AreEqual(parameters.ProductType, this.ProductType.SelectedOption.Text, "Product type");
            Assert.AreEqual(parameters.LoanAmount, this.LoanAmount.SelectedOption.Text, "Loan amount");
            Assert.AreEqual(parameters.LoanRate, this.LoanRate.SelectedOption.Text, "Loan rate");
            Assert.AreEqual(parameters.MonthlyAmount, this.MonthlyAmount.GetAttribute("value").ToString(), "Monthly amount");
            Assert.AreEqual(parameters.PaymentDate, this.PaymentDate.SelectedOption.Text, "Payment date");
            Assert.AreEqual(parameters.LoanPurpose, this.LoanPurpose.SelectedOption.Text, "Loan purpose");
            Assert.AreEqual(parameters.RequestSource, this.RequestSource.SelectedOption.Text, "Request source");
        }
    }
}
