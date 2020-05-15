namespace AdminPanelUITests.Pages.Settings.APSettingGlobalOptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;
    using BaseUITests;

    public partial class APSettingsGlobalOptionsPage
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
            Assert.IsTrue(this.ModifiedBy.Displayed, "Modified By is not displayed");
            Assert.IsTrue(this.ModifiedOn.Displayed, "Modified On is not displayed");
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

        internal void AssertPage(String url)
        {
            Assert.IsTrue(this.Driver.Url.Equals(url), "Wrong page! The URL must be: " + url + "But actual is: " + this.Driver.Url.ToString());
        }

        /// <summary>
        /// Assert no results in list.
        /// </summary>
        internal void AssertValidationMsg()
        {
            Assert.IsTrue(this.ValidationMsg.Count >= 1, "Missing validation messages");
        }

        internal void AssertNoValidationMsg()
        {
            string msgs = string.Empty;
            foreach (var msg in this.ValidationMsg)
            {
                msgs = msg + " " + msg.Text;
            }

            Assert.IsTrue(this.ValidationMsg.Count == 0, "Validation messages" + msgs);
        }
    }
}
