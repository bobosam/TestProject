namespace CRMUITests.Pages.Applicaton.IncomePage
{
    using DataDriven.Models.CRM.Applicaton;
    using OpenQA.Selenium;
 
    public partial class IncomePage : ApplicationMainPage
    {
        public IncomePage(IWebDriver driver) : base(driver)
        {
        }

        public void FillIncome(Address address, Incomes income)
        {
            this.SelectByText(this.IncomeType, income.IncomeType);
            this.SelectByText(this.EmploymentType, income.EmploymentType);
            this.SelectByText(this.WorkedPeriod, income.WorkedPeriod);
            this.SelectByText(this.BusinessSector, income.BusinessSector);

            if (income.ContractType != null)
            {
                this.SelectByText(this.ContractType, income.ContractType);
                this.Type(this.ContractDeadline, income.ContractDeadline);
            }

            this.Type(this.Employer, income.Employer);
            this.CurrentEmployer.Click();
            this.Type(this.TermTypePeriod, income.TermTypePeriod);
            this.Type(this.Position, income.Position);
            this.CurrentPosition.Click();
            this.Type(this.Salary, income.Salary);
            this.Type(this.NetSalary, income.NetSalary);
            this.SelectByText(this.SalaryRecieveType, income.SalaryRecieveType);
            this.Type(this.MobilePhone, income.MobilePhone);
            this.Type(this.MobileContactName, income.MobileContactName);
            this.Type(this.StacionaryPhone, income.StacionaryPhone);
            this.Type(this.StacionaryContactName, income.StacionaryContactName);
            this.Type(this.EmployerSettlementDropDown, address.Settlement);
            this.EmployerCurrentSettlement.Click();

            this.AssertAutoFieldsData(address, income);

            this.Type(this.EmployerNeighbourhood, address.Neighbourhood);
            this.EmployerCurrentNeighbourhood.Click();
            this.Type(this.EmployerStreet, address.StreetName);
            this.EmployerCurrentStreet.Click();
            this.Type(this.EmployerStreetNumber, address.Number);
            this.Type(this.EmployerBlock, address.Block);
            this.Type(this.EmployerEntrance, address.Entrance);
            this.Type(this.EmployerFloor, address.Floor);
            this.Type(this.EmployerApartment, address.Apartment);
        }
    }
}
