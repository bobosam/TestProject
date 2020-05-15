namespace CRMUITests.Pages.Settings.ContactPersonTypePage
{
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public partial class ContactPersonTypePage
    {
        internal void AssertChanges(ContactPersonType contactType)
        {
            this.GetResult(1);

            if (!contactType.Name.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Name.GetAttribute("value").Equals(contactType.Name), "Unsuccesfull Edit on field Name. Actual is: " + this.Name.GetAttribute("value").ToString() + "expected is: " + contactType.Name);
            }

            if (!contactType.Description.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Description.GetAttribute("value").Equals(contactType.Description), "Unsuccesfull Edit on field Description. Actual is: " + this.DisplayOrder.GetAttribute("value").ToString() + "expected is: " + contactType.DisplayOrder);
            }

            if (!contactType.Group.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Group.SelectedOption.GetAttribute("text").Equals(contactType.Group), "Unsuccesfull Edit on field Group. Actual is: " + this.Group.SelectedOption.GetAttribute("text").ToString() + "expected is: " + contactType.Group);
            }

            if (!contactType.Code.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Code.GetAttribute("value").Equals(contactType.Code), "Unsuccesfull Edit on field Code. Actual is: " + this.DisplayOrder.GetAttribute("value").ToString() + "expected is: " + contactType.Code);
            }

            if (!contactType.DisplayOrder.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.DisplayOrder.GetAttribute("value").Equals(contactType.DisplayOrder), "Unsuccesfull Edit on field DisplayOrder. Actual is: " + this.DisplayOrder.GetAttribute("value").ToString() + "expected is: " + contactType.DisplayOrder);
            }
        }
    }
}
