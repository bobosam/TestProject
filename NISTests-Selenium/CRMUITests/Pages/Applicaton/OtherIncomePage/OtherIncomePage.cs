namespace CRMUITests.Pages.Applicaton.OtherIncomePage
{
    using CDataDriven.Models.CRM.Applicaton;
    using OpenQA.Selenium;
   
    public partial class OtherIncomePage : ApplicationMainPage
    {
        public OtherIncomePage(IWebDriver driver) : base(driver)
        {
        }

        public void FillOtherIncome(OtherIncomes otherIncome)
        {
            this.Type(this.AdditionalContracts, otherIncome.AdditionalContracts);
            this.Type(this.Rent, otherIncome.Rent);
            this.Type(this.SupportMoney, otherIncome.SupportMoney);
            this.Type(this.ChildMoney, otherIncome.ChildMoney);
            this.Type(this.Transact, otherIncome.Translation);
            this.Type(this.OtherGains, otherIncome.OtherGains);
            this.Type(this.Comment, otherIncome.Comment);
        }
    }
}
