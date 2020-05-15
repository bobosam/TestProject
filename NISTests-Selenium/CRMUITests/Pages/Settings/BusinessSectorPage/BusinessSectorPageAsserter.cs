namespace CRMUITests.Pages.Settings.BusinessSectorPage
{
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class BusinessSectorPage
    {
        internal void AssertChanges(BusinessSector bSector)
        {
            this.GetResult(1);

            if (!bSector.Name.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Name.GetAttribute("value").Equals(bSector.Name), "Unsuccesfull Edit on field Name. Actual is: " + this.Name.GetAttribute("value").ToString() + "expected is: " + bSector.Name);
            }

            if (!bSector.Description.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Description.GetAttribute("value").Equals(bSector.Description), "Unsuccesfull Edit on field Description. Actual is: " + this.DisplayOrder.GetAttribute("value").ToString() + "expected is: " + bSector.DisplayOrder);
            }

            if (!bSector.DisplayOrder.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.DisplayOrder.GetAttribute("value").Equals(bSector.DisplayOrder), "Unsuccesfull Edit on field DisplayOrder. Actual is: " + this.DisplayOrder.GetAttribute("value").ToString() + "expected is: " + bSector.DisplayOrder);
            }
        }
    }
}
