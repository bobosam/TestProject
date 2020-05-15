namespace CRMUITests.Pages.Settings.SettingsGlobalOptions
{
    using BaseUITests;
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Threading;

    public partial class SettingsGlobalOptionsPage : BasePage
    {
        public IList<IWebElement> elements;

        public SettingsGlobalOptionsPage(IWebDriver driver) : base(driver)
        {
        }

        public void NavigateToSettings()
        {
            Thread.Sleep(1500);
            this.Settings.Click();
        }

        public void NavigateToBank()
        {
            this.Banks.Click();
        }

        internal void NavigateToBusinessSector()
        {
            this.BusinessSectors.Click();
        }

        internal void NavigateToContactPersonTypes()
        {
            this.ContactPersonTypes.Click();
        }

        internal void NavigateToIncomeTermTypes()
        {
            this.IncomeTermTypes.Click();
        }

        internal void NavigateToOffices()
        {
            this.Offices.Click();
        }

        internal void NavigateToParameters()
        {
            this.Parameters.Click();
        }

        internal void NavigateToPartners()
        {
            this.Partners.Click();
        }

        internal void NavigateToPriorities()
        {
            this.Priorities.Click();
        }

        internal void NavigateToSources()
        {
            this.Sources.Click();
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

        internal void DeleteAllResult()
        {
            for(int i = 1; i < this.List.Count; i++)
            {
                this.GetResult(i);
                this.ClickDelete();
                this.ClickYes();
            }
        }
    }
}
