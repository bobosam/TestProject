namespace CRMUITests.Pages.Applicaton.AdditionalInfoPage
{
    using DataDriven.Models.CRM.Applicaton;
    using OpenQA.Selenium;

    public partial class AdditionalInfoPage : ApplicationMainPage
    {
        public AdditionalInfoPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillAdditionalInfoPage(GeneralInfo info)
        {
            //this.FillAdditionalInfoData(info);
            //this.Type(this.PartnersFirstName, info.PartnerFirstName);
            //this.Type(this.PartnersSecondName, info.PartnerSecondName);
            //this.Type(this.PartnersLastName, info.PartnerLastName);
            //this.Type(this.PartnersPid, info.PartnerPid);

            //this.AssertAutoFieldsData(info);

            //this.Type(this.PartnersSalary, info.PartnerSalary);
        }

        public void FillCDAdditionalInfoPage(GeneralInfo info)
        {
            this.SelectByText(this.JDConnectionPersonType, info.JDConnectionPersonType);
            this.FillAdditionalInfoData(info);
        }

        private void FillAdditionalInfoData(GeneralInfo info)
        {
            this.SelectByText(this.MaritalStatus, info.MaritalStatus);
            this.Type(this.ChildrenCount, info.ChildrensCount);
            this.SelectByText(this.ЕducationDegrees, info.Education);
           // this.SelectByText(this.HasPersonalCar, info.HasCar);
            this.SelectByText(this.HighPublicOfficial, info.IsHighPublicOfficial);
        }
    }
}
