namespace AdminPanelUITests.Pages.Settings.APSettingGlobalOptions
{
    using BaseUITests;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public partial class APSettingsGlobalOptionsPage : BasePage
    {
        public IList<IWebElement> elements;

        public APSettingsGlobalOptionsPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToSettings()
        {
            Thread.Sleep(1500);
            this.Settings.Click();
        }

        public void NavigateToRoles()
        {
            this.Roles.Click();
        }

        internal void NavigateToPositions()
        {
            this.Positions.Click();
        }

        internal void NavigateToPermissions()
        {
            this.Permissions.Click();
        }

        internal void NavigateToJobs()
        {
            this.Jobs.Click();
        }

        internal void ClickAdd()
        {
            this.AddNew.Click();
        }

        internal void ClickSave()
        {
            this.Save.Click();
        }

        internal void ClickEdit()
        {
            this.Edit.Click();
        }

        internal void ClickReject()
        {
            this.Reject.Click();
        }

        internal void ClickDelete()
        {
            this.DeleteIt.Click();
        }

        internal void ClickDeleteModal()
        {
            this.ModalDelete.Click();
        }

        internal void ClickEditModal()
        {
            this.ModalEdit.Click();
        }

        internal void ClickRejectModal()
        {
            this.ModalReject.Click();
        }

        /// <summary>
        /// Confirm making changes.
        /// </summary>
        internal void ClickYes()
        {
            this.Yes.Click();
            Thread.Sleep(500);
        }

        /// <summary>
        /// Refuse making changes.
        /// </summary>
        internal void ClickNo()
        {
            this.No.Click();
        }

        /// <summary>
        /// Type in searchbox.
        /// </summary>
        /// <param name="objectName"></param>
        internal void Search(String objectName)
        {
            Thread.Sleep(1000);
            Type(this.SearchField, objectName);
            Thread.Sleep(500);
            this.AssertValuesInList();
        }

        /// <summary>
        /// Click on (open in View Mode) specific element(number) in the list.
        /// </summary>
        /// <param name="number"></param>
        internal void GetResult(int number)
        {
            
                this.List[number].Click();
        }
    }
}
