namespace CRMUITests.Pages.Settings.SettingsGlobalOptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using OpenQA.Selenium;

    public partial class SettingsGlobalOptionsPage
    {
        private IWebElement Settings
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Настройки')]"));
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

        private IWebElement Banks
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Банки')]"));
            }
        }

        private IWebElement BusinessSectors
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Бизнес')]"));
            }
        }

        private IWebElement ContactPersonTypes
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'лица за контакт')]"));
            }
        }

        private IWebElement IncomeTermTypes
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Вид правоотношения')]"));
            }
        }

        private IWebElement Offices
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Офиси')]"));
            }
        }

        private IWebElement Parameters
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Параметри')]"));
            }
        }

        private IWebElement Partners
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Партньори')]"));
            }
        }

        private IWebElement Priorities
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Приоритизиране')]"));
            }
        }

        private IWebElement Sources
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Източници')]"));
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
        #endregion
    }
}
