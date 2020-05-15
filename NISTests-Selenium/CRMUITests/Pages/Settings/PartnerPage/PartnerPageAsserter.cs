namespace CRMUITests.Pages.Settings.PartnerPage
{
    using System;

    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class PartnerPage
    {
        internal void AssertChanges(Partner partner)
        {
            this.GetResult(1);

            if (!partner.Name.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Name.GetAttribute("value").Equals(partner.Name), "Unsuccesfull Edit on field Name. Actual is: " + this.Name.GetAttribute("value").ToString() + "expected is: " + partner.Name);
            }

            if (!partner.IsActive.Equals(string.Empty))
            {
                Assert.IsTrue(this.IsActive.Selected == partner.IsActive, "Unsuccesfull Edit on field IsActive. Actual is: " + this.IsActive.Selected.ToString() + "expected is: " + partner.IsActive.ToString());
            }
        }

        internal void AssertDeleted(Partner partner)
        {
            this.Search(partner.Name);

            bool cond = false;
            try
            {
                this.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                cond = true;
            }

            Assert.IsTrue(cond, "Partner with the same name still exist " + partner.Name);
        }
    }
}
