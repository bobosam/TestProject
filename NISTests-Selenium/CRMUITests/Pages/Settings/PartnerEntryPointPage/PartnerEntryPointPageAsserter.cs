namespace CRMUITests.Pages.Settings.PartnerEntryPointPage
{
    using System;

    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;

    public partial class PartnerEntryPointPage
    {
        internal void AssertChanges(PartnerEntryPoint entryPoint)
        {
            this.Driver.FindElement(By.XPath(string.Format("//*[contains(text(),'{0}')]", entryPoint.Name))).Click();

            if (!entryPoint.Name.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.Name.GetAttribute("value").Equals(entryPoint.Name), "Unsuccesfull Edit on field Name. Actual is: " + this.Name.GetAttribute("value").ToString() + "expected is: " + entryPoint.Name);
            }

            if (!entryPoint.DisplayOrder.Trim().Equals(string.Empty))
            {
                Assert.IsTrue(this.DisplayOrder.GetAttribute("value").Equals(entryPoint.DisplayOrder), "Unsuccesfull Edit on field DisplayOrder. Actual is: " + this.DisplayOrder.GetAttribute("value").ToString() + "expected is: " + entryPoint.DisplayOrder);
            }

            if (!entryPoint.IsActive.Equals(string.Empty))
            {
                Assert.IsTrue(this.IsActive.Selected == entryPoint.IsActive, "Unsuccesfull Edit on field IsActive. Actual is: " + this.IsActive.Selected.ToString() + "expected is: " + entryPoint.IsActive.ToString());
            }

            if (!entryPoint.IsPhysically.Equals(string.Empty))
            {
                Assert.IsTrue(this.IsPhysically.Selected == entryPoint.IsPhysically, "Unsuccesfull Edit on field IsActive. Actual is: " + this.IsPhysically.Selected.ToString() + "expected is: " + entryPoint.IsPhysically.ToString());
            }

            if (!entryPoint.IsSystem.Equals(string.Empty))
            {
                Assert.IsTrue(this.IsSystem.Selected == entryPoint.IsSystem, "Unsuccesfull Edit on field IsActive. Actual is: " + this.IsSystem.Selected.ToString() + "expected is: " + entryPoint.IsSystem.ToString());
            }
        }

        internal void AssertDeleted(PartnerEntryPoint entryPoint)
        {
            this.Search(entryPoint.Partner);
            this.GetResult(1);
            bool cond = false;
            try
            {
                this.Driver.FindElement(By.XPath(string.Format("//*[contains(text(),'{0}')]", entryPoint.Name)));
            }
            catch (NoSuchElementException)
            {
                cond = true;
            }

            Assert.IsTrue(cond, "Entry point is not deleted " + entryPoint.Name);
        }

        internal void AssertNewEntryPointIsListed(string searchText)
        {
            bool cond = false;
            try
            {
                for (int i = 1; i < this.EPointsList.Count; i++)
                {
                    if (this.EPointsList[i].Text.Contains(searchText))
                    {
                        cond = true;
                        break;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                cond = false;
            }

            Assert.IsTrue(cond, "No matches with this name: " + searchText);
        }
    }
}
