namespace CRMUITests.Pages.Applicaton.AddressPage
{
    using DataDriven.Models.CRM.Applicaton;
    using OpenQA.Selenium;
    using Pages.HomePage;
    using Pages.Applicaton.LoanParametersPage;
    using Pages.Applicaton.PersonalDataPage;
    using DataDriven;
    using OpenQA.Selenium.Support.UI;
    using System.Threading;
    using System.Collections.Generic;

    public partial class AddressPage : ApplicationMainPage
    {
        public AddressPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillAddress(Address address, int index)
        {
            this.Type(this.SettlementDropDowns[index], address.Settlement);
            Thread.Sleep(1000);
            this.CurrentSettlement(index).Click();

            Thread.Sleep(1000);
            this.AssertAutoFieldsData(address, index);

            this.Type(this.Neighbourhoods[index], address.Neighbourhood);
            Thread.Sleep(1000);
            if (!string.IsNullOrEmpty(address.Neighbourhood))
            {
                this.GetCurrentNeighbourhood(index).Click();
            }

            this.Type(this.StreetNames[index], address.StreetName);
            Thread.Sleep(1000);
            if (!string.IsNullOrEmpty(address.StreetName))
            {
                this.GetCurrentStreet(index).Click();
            }

            this.Type(this.StreetNumbers[index], address.StreetNumber);
            this.Type(this.Blocks[index], address.Block);
            this.Type(this.Entrences[index], address.Entrance);
            this.Type(this.Floors[index], address.Floor);
            this.Type(this.ApartmentNumbers[index], address.Apartment);

            try
            {
                var text = this.HomeTypeSelect.SelectedOption.Text;
            }
            catch (System.Exception)
            {
                if (!string.IsNullOrEmpty(address.HomeType))
                {
                    this.SelectByText(this.HomeTypeSelect, address.HomeType);
                }
            }

            try
            {
                var text = this.ResidencePeriods.SelectedOption.Text;
            }
            catch (System.Exception)
            {
                if (!string.IsNullOrEmpty(address.ResidencePeriod))
                {
                    this.SelectByText(this.ResidencePeriods, address.ResidencePeriod);
                }
            }
        }

        public void FillAllAddresses(List<Address> addresses)
        {
            this.FillAddress(addresses[0], 0);
            this.AssertForIndenticalAddres();
            this.DifferentAddressesRadioButton.Click();
            this.AssertForDifferentAddres();
            this.FillAddress(addresses[1], 1);
            this.CheckDifferentAddresses.Click();
            Thread.Sleep(500);
            this.AssertForNotIndenticalAddres();
            this.FillAddress(addresses[2], 2);
        }

        public void FillPreviousData(
                                    HomePage homePage,
                                    ApplicationMainPage applicationMainPage,
                                    LoanParametersPage loanParamPage,
                                    PersonalDataPage personalDataPage,
                                    string pid)
        {
            personalDataPage.FillPreviousData(homePage, applicationMainPage, loanParamPage, pid);
            var personalData = AccessExcelData.GetTestData<PersonalData>("TestName", "valid", "PersonalData", CRMConstants.ApplicationXlsxFilename);
            personalData.Pid = pid;
            personalData.BirthDate = HelpMethods.GetBirthDayByPid(pid);
            personalDataPage.FillPersonalData(personalData);
            applicationMainPage.SaveAndContinueButton.Click();
        }
    }
}
