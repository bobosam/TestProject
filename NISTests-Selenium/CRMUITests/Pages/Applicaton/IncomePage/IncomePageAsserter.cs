namespace CRMUITests.Pages.Applicaton.IncomePage
{
    using DataDriven.Models.CRM.Applicaton;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
   
    public partial class IncomePage
    {
        public void AssertApplicationPage()
        {
            base.AssertApplicationPage("Доходи");
        }

        public void AssertAutoFieldsData(Address address, Incomes income)
        {
            var eik = this.Eik.GetAttribute("value");
            var region = this.EmployerDistrict.GetAttribute("value");
            var area = this.EmployerMunicipality.GetAttribute("value");
            var zip = this.EmployerZip.GetAttribute("value");

            Assert.IsTrue(eik == income.Eik);
            Assert.IsTrue(region == address.Region);
            Assert.IsTrue(area == address.Area);
            Assert.IsTrue(zip == address.Zip);
        }
    }
}
