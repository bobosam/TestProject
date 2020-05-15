namespace CRMUITests.Pages.Request.RequestMainPage
{
    using System.Collections.Generic;
    using OpenQA.Selenium;

    public partial class RequestMainPage
    {
        #region Request Grid
        public IWebElement FirstRequestID
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='offers-table']/table/tbody/tr[1]/td[1]"));
            }
        }

        public List<IWebElement> AllRequestID
        {
            get
            {
                return new List<IWebElement>(this.FindElements(By.XPath("//*[@id='offers-table']/table/tbody/tr/td[1]")));
            }
        }

        public IWebElement FirstRequestName
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='offers-table']/table/tbody/tr[1]/td[2]"));
            }
        }

        public IWebElement FirstRequestPhoneNumber
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='offers-table']/table/tbody/tr[1]/td[3]"));
            }
        }

        public IWebElement FirstRequestClientType
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='offers-table']/table/tbody/tr[1]/td[4]"));
            }
        }

        public IWebElement FirstRequestSource
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='offers-table']/table/tbody/tr[1]/td[5]"));
            }
        }

        public IWebElement FirstRequestCreatedOn
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='offers-table']/table/tbody/tr[1]/td[6]"));
            }
        }

        public List<IWebElement> AllRequestCreatedOn
        {
            get
            {
                return new List<IWebElement>(this.FindElements(By.XPath("//*[@id='offers-table']/table/tbody/tr/td[6]")));
            }
        }

        public IWebElement FirstRequestStatus
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='offers-table']/table/tbody/tr[1]/td[7]"));
            }
        }

        public IWebElement FirstRequestPriority
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='offers-table']/table/tbody/tr[1]/td[8]"));
            }
        }

        #endregion

        #region Detals
        public IWebElement DetailsRequestId
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-request-id"));
            }
        }

        public IWebElement DetailsButton
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-request-id-button"));
            }
        }

        public IWebElement DetailsStatus
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-request-status"));
            }
        }

        public IWebElement DetailsSource
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-request-source"));
            }
        }

        public IWebElement DetailstPriority
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-request-priority"));
            }
        }

        public IWebElement DetailsClientCardButton
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Потенциален клиент: ')]/img"));
            }
        }

        public IWebElement DetailsClientName
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-potential-client-name"));
            }
        }

        public IWebElement DetailsClientPhone
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-potential-client-phone"));
            }
        }

        public IWebElement DetailsClientType
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-potential-client-type"));
            }
        }

        public IWebElement DetailsOfficeName
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-office-name"));
            }
        }

        public IWebElement DetailsOfficeRegion
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-office-region"));
            }
        }

        public IWebElement DetailsOfficeArea
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-office-area"));
            }
        }

        public IWebElement DetailsOfficeSubarea
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-office-subarea"));
            }
        }

        public IWebElement DetailsKEName
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-credit-expert-name"));
            }
        }

        public IWebElement DetailsKECode
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-credit-expert-code"));
            }
        }

        public IWebElement DetailsActions
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'ДЕЙСТВИЯ')]"));
            }
        }

        #endregion

        #region Modal Details
        public IWebElement ModalDetailsRequestNumber
        {
            get
            {
                return this.FindElement(By.XPath("//strong[contains(text(), 'Номер на заявка: ')]/.."));
            }
        }

        public IWebElement ModalDetailsStatus
        {
            get
            {
                return this.FindElement(By.XPath("//strong[contains(text(), 'Статус: ')]/.."));
            }
        }

        public IWebElement ModalDetailsClientType
        {
            get
            {
                return this.FindElement(By.XPath("//strong[contains(text(), 'Тип клиент: ')]/.."));
            }
        }

        public IWebElement ModalDetailsSource
        {
            get
            {
                return this.FindElement(By.XPath("//strong[contains(text(), 'Източник: ')]/.."));
            }
        }

        public IWebElement ModalDetailsPriority
        {
            get
            {
                return this.FindElement(By.XPath("//strong[contains(text(), 'Текущ приоритет: ')]/.."));
            }
        }

        public IWebElement ModalDetailsCreatedOn
        {
            get
            {
                return this.FindElement(By.XPath("//strong[contains(text(), 'Дата на постъпване: ')]/.."));
            }
        }

        public IWebElement ModalDetailsOperatorName
        {
            get
            {
                return this.FindElement(By.XPath("//strong[contains(text(), 'Имена на оператор: ')]/.."));
            }
        }

        public IWebElement ModalDetailsHistory
        {
            get
            {
                return this.FindElement(By.XPath("//strong[contains(text(), 'Последно извършено действие: ')]/.."));
            }
        }

        public IWebElement ModalDetailsClosingButton
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-actions-modal-close-button"));
            }
        }

        #endregion

        #region Actions
        public IWebElement DetailsActionsToOffer
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-actions-modal-to-offer-button"));
            }
        }

        public IWebElement DetailsActionsRedistribution
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-actions-modal-change-office-button"));
            }
        }

        public IWebElement DetailsActionsCloseButtons
        {
            get
            {
                return this.FindElement(By.Id("requests-list-details-actions-modal-close-button"));
            }
        }

        public IWebElement RedistrbutionToTS
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Телепродажби')]"));
            }
        }

        public IWebElement RedistrbutionToSN
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Търговска мрежа')]"));
            }
        }

        public IWebElement Redistribute
        {
            get
            {
                return this.FindElement(By.Id("redistribute-request-button"));
            }
        }

        public IWebElement CanselRedistribution
        {
            get
            {
                return this.FindElement(By.Id("cancel-redistribution-button"));
            }
        }

        public IWebElement SubareaRedistributionCheck
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Район')]"));
            }
        }

        public IWebElement OffisRedistribution
        {
            get
            {
                return this.FindElement(By.CssSelector("#office-radio-button > label"));
            }
        }

        public IWebElement RedstrbutionSelectOrganizatonUnit
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Изберете район:')]/../../p-autocomplete/span/input"));
            }
        }

        public IWebElement RedstrbutionSelectOrganizatonUnitFirst
        {
            get
            {
                return this.FindElement(By.CssSelector("#organization-units-autocomplete > span > div > ul > li:nth-child(1)"));
            }
        }

        public IWebElement RedstrbutionSelectOffices
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Изберете офис:')]/../../p-autocomplete/span/input"));
            }
        }

        public IWebElement RedstrbutionSelectOfficesFirst
        {
            get
            {
                return this.FindElement(By.CssSelector("#offices-autocomplete > span > div > ul > li:nth-child(1)"));
            }
        }

        public IWebElement RedstrbutionOfficeAddress
        {
            get
            {
                return this.FindElement(By.Id("office-address"));
            }
        }

        public IWebElement RedstrbutionOrganizationUnitDropdown
        {
            get
            {
                return this.FindElement(By.CssSelector("#organization-units-dropdown > div > div.ui-dropdown-trigger.ui-state-default.ui-corner-right > span"));
            }
        }

        public IWebElement RedstrbutionOrganizationUnitDropdownFirst
        {
            get
            {
                return this.FindElement(By.CssSelector("#organization-units-dropdown > div > div.ui-dropdown-panel.ui-widget-content.ui-corner-all.ui-helper-hidden.ui-shadow > div > ul > li:nth-child(2)"));
            }
        }

        #endregion
    }
}
