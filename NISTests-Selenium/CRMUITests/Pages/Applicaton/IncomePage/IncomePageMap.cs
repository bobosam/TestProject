namespace CRMUITests.Pages.Applicaton.IncomePage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class IncomePage
    {
        public SelectElement IncomeType
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("incomeTypes-0")));
            }
        }

        public SelectElement EmploymentType
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("'employmentType'+0")));
            }
        }

        public SelectElement WorkedPeriod
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("'workPeriods'+0")));
            }
        }

        public SelectElement BusinessSector
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("businessSectors-0")));
            }
        }

        public SelectElement ContractType
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("employment-contract-type")));
            }
        }

        public IWebElement ContractDeadline
        {
            get
            {
                return this.FindElement(By.CssSelector("#contract-expiration > span > input"));
            }
        }

        public IWebElement Employer
        {
            get
            {
                return this.FindElement(By.CssSelector("#EmployerNames-0 > span > input"));
            }
        }

        public IWebElement CurrentEmployer
        {
            get
            {
                return this.FindElement(By.CssSelector("#EmployerNames-0 > span > div > ul > li:nth-child(1) > span"));
            }
        }

        public IWebElement Eik
        {
            get
            {
                return this.FindElement(By.Id("Bulstat-0"));
            }
        }

        public IWebElement TermTypePeriod
        {
            get
            {
                return this.FindElement(By.Id("TotalServiceLengthInMonthsWithCurrentEmployer-0"));
            }
        }

        public IWebElement Position
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Длъжност:')]/../p-autocomplete/span/input"));
            }
        }

        public IWebElement CurrentPosition
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Длъжност:')]/../p-autocomplete/span/div/ul/li"));
            }
        }

        public IWebElement Salary
        {
            get
            {
                return this.FindElement(By.Id("InsuranceIncomeInLv"));
            }
        }

        public IWebElement NetSalary
        {
            get
            {
                return this.FindElement(By.Id("Salary-0"));
            }
        }

        public SelectElement SalaryRecieveType
        {
            get
            {
                return new SelectElement(this.FindElement(By.Id("salaryReceivingMethods-0")));
            }
        }

        public IWebElement MobilePhone
        {
            get
            {
                return this.FindElement(By.Id("BusinessMobileNumber-0"));
            }
        }

        public IWebElement MobileContactName
        {
            get
            {
                return this.FindElement(By.Id("ContactPersonInfo-0"));
            }
        }

        public IWebElement StacionaryPhone
        {
            get
            {
                return this.FindElement(By.Id("BusinessStationaryNumber-0"));
            }
        }

        public IWebElement StacionaryContactName
        {
            get
            {
                return this.FindElement(By.Id("ContactPersonStationaryInfo-0"));
            }
        }

        public IWebElement EmployerSettlementDropDown
        {
            get
            {
                return this.FindElement(By.CssSelector("#settlementDropDown\\27 \\20 \\2b \\20 0 > span > input"));
            }
        }

        public IWebElement EmployerCurrentSettlement
        {
            get
            {
                return this.FindElement(By.CssSelector("#settlementDropDown\\27 \\20 \\2b \\20 0 > span > div > ul > li:nth-child(1) > span"));
            }
        }

        public IWebElement EmployerDistrict
        {
            get
            {
                return this.FindElement(By.Id("district-0"));
            }
        }

        public IWebElement EmployerMunicipality
        {
            get
            {
                return this.FindElement(By.Id("municipality-0"));
            }
        }

        public IWebElement EmployerZip
        {
            get
            {
                return this.FindElement(By.Id("postCode-0"));
            }
        }

        public IWebElement EmployerNeighbourhood
        {
            get
            {
                return this.FindElement(By.CssSelector("#\\27 hood\\27 \\2b 0 > span > input"));
            }
        }

        public IWebElement EmployerCurrentNeighbourhood
        {
            get
            {
                return this.FindElement(By.CssSelector("#\\27 hood\\27 \\2b 0 > span > div > ul > li:nth-child(1)"));
            }
        }

        public IWebElement EmployerStreet
        {
            get
            {
                return this.FindElement(By.CssSelector("#\\27 streets\\27 \\2b 0 > span > input"));
            }
        }

        public IWebElement EmployerCurrentStreet
        {
            get
            {
                return this.FindElement(By.CssSelector("#\\27 streets\\27 \\2b 0 > span > div > ul > li > span"));
            }
        }

        public IWebElement EmployerStreetNumber
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), '№:')]/../input"));
            }
        }

        public IWebElement EmployerBlock
        {
            get
            {
                return this.FindElement(By.Id("text-0"));
            }
        }

        public IWebElement EmployerEntrance
        {
            get
            {
                return this.FindElement(By.Id("enterence-0"));
            }
        }

        public IWebElement EmployerFloor
        {
            get
            {
                return this.FindElement(By.Id("stage-0"));
            }
        }

        public IWebElement EmployerApartment
        {
            get
            {
                return this.FindElement(By.Id("apartamentNumber-0"));
            }
        }
    }
}
