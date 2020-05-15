namespace CRMUITests.Pages.Settings.SettingsGlobalOptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;

    public partial class SettingsGlobalOptionsPage
    {
        /// <summary>
        /// Assert List contains result.
        /// </summary>
        internal void AssertValuesInList()
        {
            Assert.IsTrue(this.List.Count >= 1, "No result found");
        }

        /// <summary>
        /// Assert all audit fields present.
        /// </summary>
        internal void AssertAuditFields()
        {
            Assert.IsTrue(this.CreateBy.Displayed, "Created By is not displayed");
            Assert.IsTrue(this.CreateOn.Displayed, "Created On is not displayed");
        }

        /// <summary>
        /// Type Name in Search Field and assert that all result contains the text.
        /// </summary>
        /// <param name="searchText"></param>
        internal void AssertNewEntryIsListed(String searchText)
        {
            Thread.Sleep(1000);
            Type(this.SearchField, searchText);
            try
            {
                
                Assert.IsTrue(this.List[1].Text.Contains(searchText), "Wrong search" + this.List[1].Text);
            }
            catch (ArgumentOutOfRangeException)
            {
                Assert.IsTrue(false, "No matches with this name: " + searchText);
            }
            
        }

        /// <summary>
        /// Assert no results in list.
        /// </summary>
        internal void AssertNoResult()
        {
                Assert.IsTrue(this.List.Count == 1, "There are results");
        }
    }
}
