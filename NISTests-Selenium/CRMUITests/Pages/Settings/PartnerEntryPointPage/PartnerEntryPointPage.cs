namespace CRMUITests.Pages.Settings.PartnerEntryPointPage
{
    using System;
    using System.Threading;

    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven.Models.CRM.Settings;
    using OpenQA.Selenium;
    using System.Collections.Generic;

    public partial class PartnerEntryPointPage : SettingsGlobalOptionsPage
    {
        public PartnerEntryPointPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Add new Entry Point to existing Partner.
        /// </summary>
        /// <param name="entryPoint"></param>
        internal void AddNew(PartnerEntryPoint entryPoint)
        {
            this.Search(entryPoint.Partner);
            this.GetResult(1);
            this.AddEntryPoint.Click();

            this.Type(this.Name, entryPoint.Name);
            this.Type(this.DisplayOrder, entryPoint.DisplayOrder);

            if (!entryPoint.IsActive)
            {
                this.IsActive.Click();
            }

            if (entryPoint.IsPhysically)
            {
                this.IsPhysically.Click();
            }

            if (entryPoint.IsSystem)
            {
                this.IsSystem.Click();
            }

            this.ClickSave();

            Thread.Sleep(500);
        }

        /// <summary>
        /// Search Partner to edit. Click on button Edit. Check fields and edit them.
        /// </summary>
        /// <param name="entryPoint"></param>
        internal void Edit(PartnerEntryPoint entryPoint)
        {
            this.Search(entryPoint.Partner);
            this.GetResult(1);
            Thread.Sleep(500);
            this.Driver.FindElement(By.XPath(string.Format("//*[contains(text(),'{0}')]", entryPoint.Name))).Click();
            this.ClickEditModal();

            if (!this.Name.GetAttribute("value").Equals(entryPoint.Name) || !entryPoint.Name.Trim().Equals(string.Empty))
            {
                this.Type(this.Name, entryPoint.Name);
            }

            if (!this.DisplayOrder.GetAttribute("value").Equals(entryPoint.DisplayOrder) || !entryPoint.DisplayOrder.Trim().Equals(string.Empty))
            {
                this.Type(this.DisplayOrder, entryPoint.DisplayOrder);
            }

            if (!entryPoint.IsActive.Equals(string.Empty))
            {
                if (this.IsActive.Selected != entryPoint.IsActive)
                {
                    this.IsActive.Click();
                }
            }

            if (!entryPoint.IsPhysically.Equals(string.Empty))
            {
                if (this.IsPhysically.Selected != entryPoint.IsPhysically)
                {
                    this.IsPhysically.Click();
                }
            }

            if (!entryPoint.IsSystem.Equals(string.Empty))
            {
                if (this.IsSystem.Selected != entryPoint.IsSystem)
                {
                    this.IsSystem.Click();
                }
            }
                        
            this.ClickSave();
            Thread.Sleep(500);
        }

        internal void Delete(PartnerEntryPoint entryPoint)
        {
            this.Search(entryPoint.Partner);
            this.GetResult(1);
            //Thread.Sleep(500);
            //IList<IWebElement> elements = this.FindElements(By.XPath(string.Format("//*[contains(text(),'{0}')]", entryPoint.Name)));

            IList<IWebElement> elementsId = this.FindElements(By.XPath(string.Format("//*[contains(text(),'{0}')]/../td[1]", entryPoint.Name)));
            List<string> ids = new List<string>();

            foreach (var ele in elementsId)
            {
                ids.Add(ele.Text);//GetAttribute("value"));
            }

            for (int i = 0; i <= elementsId.Count; i++)
            {
                this.FindElement(By.XPath(string.Format("//*[contains(text(),'{0}')]/", ids[i]))).Click();
                this.ClickDeleteModal();
                this.ClickYes();
            }
        }
    }
}
