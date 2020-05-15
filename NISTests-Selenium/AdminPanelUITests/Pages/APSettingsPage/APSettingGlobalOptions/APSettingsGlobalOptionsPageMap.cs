namespace AdminPanelUITests.Pages.Settings.APSettingGlobalOptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;

    public partial class APSettingsGlobalOptionsPage
    {
        private IWebElement Settings
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Настройки')]"));
            }
        }

        
        private IList<IWebElement> ValidationMsg
        {
            get
            {
                return this.FindElements(By.CssSelector("div.text-center.text-white.bg-danger"));
            }
        }

        #region Global Buttons in each main Settings Page 

        private IWebElement SearchField
        {
            get
            {
                return this.FindElement(By.XPath("//input[@placeholder='Търсене']"));
            }
        }

        private IList<IWebElement> List
        {
            get
            {
                return this.FindElements(By.XPath("//tr"));
            }
        }

        private IWebElement AddNew
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Добави')]"));
            }
        }

        private IWebElement Edit
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Редактирай')]"));
            }
        }

        private IWebElement Reject
        {
            get
            {
                return this.FindElement(By.XPath("//h6/*[contains(text(),'Отказ')]"));
            }
        }

        private IWebElement DeleteIt
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Изтрий')]"));
            }
        }

        /// <summary>
        /// Save changes or new created item.
        /// </summary>
        private IWebElement Save
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Запази')]"));
            }
        }

        /// <summary>
        /// Rejection in modal window "Add new element"
        /// </summary>
        private IWebElement ModalReject
        {
            get
            {
                return this.FindElement(By.XPath("//div/button[contains(text(),'Отказ')]"));
            }
        }

        private IWebElement ModalEdit
        {
            get
            {
                return this.FindElement(By.XPath("//div/button[contains(text(),'Редактирай')]"));
            }
        }

        private IWebElement ModalDelete
        {
            get
            {
                return this.FindElement(By.XPath("//div/button[contains(text(),'Изтрий')]"));
            }
        }

        private IWebElement Yes
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(),'Да')]"));
            }
        }

        private IWebElement No
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(),'Не')]"));
            }
        }

        private IWebElement ContinueEdit
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(),'Продължи редакция')]"));
            }
        }

        #endregion

        #region List of Settings

        private IWebElement Jobs
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Длъжности')]"));
            }
        }

        private IWebElement Positions
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Позиции')]"));
            }
        }

        private IWebElement Permissions
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Права и роли')]"));
            }
        }

        private IWebElement Roles
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Роли')]"));
            }
        }

        
        #endregion

        #region Audit fields
        private IWebElement CreateBy
        {
            get
            {
                return this.FindElement(By.Id("CreateBy"));
            }
        }

        private IWebElement CreateOn
        {
            get
            {
                return this.FindElement(By.Id("CreateOn"));
            }
        }

        private IWebElement ModifiedBy
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Променена от')]/../../..//input"));
            }
        }

        private IWebElement ModifiedOn
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Променена на')]/../../..//input"));
            }
        }
        #endregion
    }
}
