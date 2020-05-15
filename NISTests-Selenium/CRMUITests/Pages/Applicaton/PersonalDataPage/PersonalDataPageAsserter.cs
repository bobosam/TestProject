namespace CRMUITests.Pages.Applicaton.PersonalDataPage
{
    using DataDriven.Models.CRM.Applicaton;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;

    public partial class PersonalDataPage
    {
        public void AssertAutoFieldsData(PersonalData data)
        {
            Thread.Sleep(1500);
            var pid = this.Pid.GetAttribute("value");
            Assert.IsTrue(pid == data.Pid);

            this.AssertCDAutoFieldsData(data);
        }

        public void AssertCDAutoFieldsData(PersonalData data)
        {
            var birthValue = this.BirthDate.GetAttribute("value");
            var gender = this.Gender.GetAttribute("value");

            Assert.IsTrue(birthValue == data.BirthDate);
            Assert.IsTrue(gender != string.Empty);
        }

        public void AssertCirilik()
        {
            Assert.AreEqual("Моля, пишете на кирилица!", this.ExceptionMessageCyrilik.Text);
            this.AssertDisabledElement(this.SaveAndContinueButton);
        }

        public void AssertWrongNumber()
        {
            Assert.AreEqual("Невалиден номер!", this.ExceptionMessageWrongNumber.Text);
            this.AssertDisabledElement(this.SaveAndContinueButton);
        }

        public void AssertWrongDate()
        {
            Assert.AreEqual("Датата е невалидна!", this.ExceptionMessageWrongDate.Text);
        }

        public void AssertMissingData()
        {
            Assert.AreEqual("Полето е задължително!", this.ExceptionMissingData.Text);
        }

        public void CheckSavedParameters(PersonalData parameters)
        {
            Assert.IsFalse(this.ApplicationNumber.GetAttribute("value").ToString().Trim() == string.Empty, "Application Number");
            Assert.AreEqual("Недовършена", this.ApplicationStatus.GetAttribute("value"), "Application Status");
            Assert.AreEqual(this.Pid.GetAttribute("value").ToString().Trim(), parameters.Pid.Trim(), "ЕГН");
            Assert.AreEqual(parameters.FirstName, this.FirstName.GetAttribute("value"), "First Name");
            Assert.AreEqual(parameters.SecondName, this.SecondName.GetAttribute("value"), "Second Name");
            Assert.AreEqual(parameters.LastName, this.LastName.GetAttribute("value"), "Last Name");
            Assert.AreEqual(parameters.PersonType, this.PersonType.SelectedOption.Text, "Person Type");
            Assert.AreEqual(parameters.BirthDate, this.BirthDate.GetAttribute("value").ToString().Trim(), "Birth Date");
            Assert.AreEqual(parameters.IdCardNumber, this.IdCardNumber.GetAttribute("value"), "IdCard Number");
            Assert.AreEqual(parameters.CardCreationDate, this.CardCreationDate.GetAttribute("value"), "Card Creation Date");
            Assert.AreEqual(parameters.CardExpirationDate, this.CardExpirationDate.GetAttribute("value"), "Card Expiration Date");
            Assert.AreEqual(parameters.CardIssuer, this.CardIssuer.Text, "Person Type");
        }
    }
}
