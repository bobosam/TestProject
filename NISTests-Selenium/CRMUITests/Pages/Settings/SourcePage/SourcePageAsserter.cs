namespace CRMUITests.Pages.Settings.SourcePage
{
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;

    public partial class SourcePage
    {
        /// <summary>
        /// Asserts text in the UI elements is correct.
        /// </summary>
        /// <param name="source"></param>
        internal void AssertChanges(Source source)
        {
            this.GetResult(1);

            if (!source.Name.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Name.GetAttribute("value").Equals(source.Name), "Unsuccesfull Edit on field Name. Actual is: " + this.Name.GetAttribute("value").ToString() + "expected is: " + source.Name);
            }

            if (!source.DisplayName.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.DisplayName.GetAttribute("value").Equals(source.DisplayName), "Unsuccesfull Edit on field DisplayName. Actual is: " + this.DisplayName.GetAttribute("value").ToString() + "expected is: " + source.DisplayName);
            }

            if (!source.Description.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Description.GetAttribute("value").Equals(source.Description), "Unsuccesfull Edit on field Description. Actual is: " + this.Description.GetAttribute("value").ToString() + "expected is: " + source.Description);
            }

            if (!source.DisplayOrder.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.DisplayOrder.GetAttribute("value").Equals(source.DisplayOrder), "Unsuccesfull Edit on field DisplayOrder. Actual is: " + this.DisplayOrder.GetAttribute("value").ToString() + "expected is: " + source.DisplayOrder);
            }

            if (!source.IsActive.Equals(string.Empty))
            {
                Assert.IsTrue(this.IsActive.Selected == source.IsActive, "Unsuccesfull Edit on field IsActive. Actual is: " + this.IsActive.Selected.ToString() + "expected is: " + source.IsActive.ToString());
            }
        }
        /// <summary>
        /// Asserts no result for this obejct in the list.
        /// </summary>
        /// <param name="source"></param>
        internal void AssertDeleted(Source source)
        {
            this.Search(source.Name);

            bool cond = false;
            try
            {
                this.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {

                cond = true;
            }
            Assert.IsTrue(cond, "Partner with the same name still exist " + source.Name);
        }
    }
}
