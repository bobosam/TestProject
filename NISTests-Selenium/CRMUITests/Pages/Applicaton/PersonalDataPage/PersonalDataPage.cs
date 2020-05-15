namespace CRMUITests.Pages.Applicaton.PersonalDataPage
{
    using System.Threading;

    using DataDriven.Models.CRM.Applicaton;
    using OpenQA.Selenium;
    using Pages.HomePage;
    using Pages.Applicaton.LoanParametersPage;
    using DataDriven;

    public partial class PersonalDataPage : ApplicationMainPage
    {
        public PersonalDataPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillPersonalData(PersonalData personalData)
        {
            this.InputName(personalData);

            this.AssertAutoFieldsData(personalData);

            if (personalData.IsForeigner)
            {
                if (!this.IsForeigner.Selected)
                {
                    this.IsForeigner.Click();
                }

                if (personalData.PersonType != null)
                {
                    this.ClicableSelectByText(this.PersonType, personalData.PersonType, Driver);
                }
            }

            this.IdCardDataFirstResult(personalData);
        }

        public void FillCDPersonalData(PersonalData personalData)
        {
            this.InputName(personalData);
            this.Type(this.Pid, personalData.Pid);
            Thread.Sleep(500);
            this.AssertCDAutoFieldsData(personalData);

            this.IdCardDataFirstResult(personalData);
        }

        public void FillPreviousData(HomePage homePage, ApplicationMainPage applicationMainPage, LoanParametersPage loanParamPage, string pid)
        {
            Thread.Sleep(1500);
            homePage.Applications.Click();
            applicationMainPage.OpenNewApplication();
            var loanParameters = AccessExcelData.GetTestData<LoanParameters>("TestName", "valid", "LoanParameters", CRMConstants.ApplicationXlsxFilename);
            loanParameters.Pid = pid;
            loanParamPage.FillLoanParameters(loanParameters);
            applicationMainPage.SaveAndContinueButton.Click();
        }

        private void InputName(PersonalData personalData)
        {
            this.Type(this.FirstName, personalData.FirstName);
            this.Type(this.SecondName, personalData.SecondName);
            this.Type(this.LastName, personalData.LastName);
        }

        private void IdCardDataFirstResult(PersonalData personalData)
        {
            this.Type(this.IdCardNumber, personalData.IdCardNumber);
            this.Type(this.CardCreationDate, personalData.CardCreationDate);
            this.Type(this.CardExpirationDate, personalData.CardExpirationDate);
            if (personalData.CardIssuer != null)
            {
                this.Type(CardIssuer, personalData.CardIssuer);
            }
        }
    }
}
