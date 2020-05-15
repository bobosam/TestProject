namespace CRMUITests.Pages.Settings.OfficePage
{
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class OfficePage
    {
        internal void AssertChanges(Office office)
        {
            this.GetResult(1);

            if (!office.Name.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Name.GetAttribute("value").Equals(office.Name), "Unsuccesfull Edit on field Name. Actual is: " + this.Name.GetAttribute("value").ToString() + " expected is: " + office.Name);
            }

            if (!office.DisplayName.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.DispayName.GetAttribute("value").Equals(office.DisplayName), "Unsuccesfull Edit on field DisplayName. Actual is: " + this.DispayName.GetAttribute("value").ToString() + " expected is: " + office.DisplayName);
            }

            if (!office.Address.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Address.GetAttribute("value").Equals(office.Address), "Unsuccesfull Edit on field Address. Actual is: " + this.DisplayOrder.GetAttribute("value").ToString() + " expected is: " + office.Address);
            }

            if (!office.Settlement.Trim().Equals(string.Empty))
            {
                //Assert.IsTrue(this.Settlement.SelectedOption.GetAttribute("value").Equals(office.Settlement), "Unsuccesfull Edit on field Settlement. Actual is: " + this.Settlement.SelectedOption.GetAttribute("value").ToString() + "expected is: " + office.Settlement);
                Assert.IsTrue(this.Settlement.GetAttribute("value").Equals(office.Settlement), "Unsuccesfull Edit on field Settlement. Actual is: " + this.Settlement.GetAttribute("value").ToString() + " expected is: " + office.Settlement);
            }

            if (!office.DisplayOrder.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.DisplayOrder.GetAttribute("value").Equals(office.DisplayOrder), "Unsuccesfull Edit on field DisplayOrder. Actual is: " + this.DisplayOrder.GetAttribute("value").ToString() + " expected is: " + office.DisplayOrder);
            }

            if (!office.IsActive.Equals(string.Empty))
            {
                Assert.IsTrue(this.IsActive.Selected == office.IsActive, "Unsuccesfull Edit on field IsActive. Actual is: " + this.IsActive.Selected.ToString() + "expected is: " + office.IsActive.ToString());
            }
        }
    }
}
