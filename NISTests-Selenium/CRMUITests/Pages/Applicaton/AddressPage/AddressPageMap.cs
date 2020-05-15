namespace CRMUITests.Pages.Applicaton.AddressPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System.Collections.Generic;

    public partial class AddressPage
    {
        public IList<IWebElement> SettlementDropDowns
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(), 'Населено място:')]/../p-autocomplete/span/input"));
            }
        }

        public IWebElement CurrentSettlement(int index)
        {
            return this.SettlementDropDowns[index].FindElement(By.XPath("../div/ul/li"));
        }

        public IList<IWebElement> Regions
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(),'Област')]/../input"));
            }
        }

        public IList<IWebElement> Areas
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(),'Община')]/../input"));
            }
        }

        public IList<IWebElement> Zips
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(),'ПК.:')]/../input"));
            }
        }

        public IList<IWebElement> Neighbourhoods
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(),'Кв. / ж.к.:')]/../../p-autocomplete/span/input"));
            }
        }

        public IWebElement GetCurrentNeighbourhood(int index)
        {
            return this.Neighbourhoods[index].FindElement(By.XPath("../div/ul/li"));
        }

        public IList<IWebElement> StreetNames
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(),'Име на ул./ бул.:')]/../../p-autocomplete/span/input"));
            }
        }

        public IWebElement GetCurrentStreet(int index)
        {
            return this.StreetNames[index].FindElement(By.XPath("../div/ul/li"));
        }

        public IList<IWebElement> StreetNumbers
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(), '№')]/../input"));
            }
        }

        public IList<IWebElement> Blocks
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(), 'Бл')]/../input"));
            }
        }

        public IList<IWebElement> Entrences
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(), 'Вх')]/../input"));
            }
        }

        public IList<IWebElement> Floors
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(), 'Ет')]/../input"));
            }
        }

        public IList<IWebElement> ApartmentNumbers
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(), 'Ап')]/../input"));
            }
        }

        public SelectElement HomeTypeSelect
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[contains(text(), 'Тип жилище:')]/../select")));
            }
        }

        public SelectElement ResidencePeriods
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[contains(text(), 'Живее на адреса от:')]/../select")));
            }
        }

        public IWebElement CheckDifferentAddresses
        {
            get
            {
                return this.FindElement(By.Id("differentAddresses"));
            }
        }

        public IWebElement IdenticalAddressesRadioButton
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Адресът за кореспонденция е идентичен с адреса по лична карта.')]/../div/div[2]"));
            }
        }

        public IWebElement DifferentAddressesRadioButton
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Адресът за кореспонденция е различен от адреса по лична карта и Настоящ адрес.')]/../div/div[2]"));
            }
        }

        public IWebElement NotIdenticalAddressesRadioButton
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Адресът за кореспонденция е идентичен с настоящия адрес')]/../div/div[2]"));
            }
        }

        public IList<IWebElement> AlertMissingData
        {
            get
            {
                return this.FindElements(By.XPath("//*[contains(text(), 'Моля, въведете стойност!')]"));
            }
        }

        public override IWebElement SaveAndContinueButton
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(),'Запиши и продължи')]"));
            }
        }

        //public IWebElement SettlementDropDown
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='clientAddressForm']/div[1]/div[2]/div[1]/p-autocomplete/span/input"));
        //    }
        //}

        //public IWebElement SettlementSelect
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='clientAddressForm']/div[1]/div[2]/div[1]/p-autocomplete/span/div/ul/li[1]/span"));
        //    }
        //}

        //public IWebElement Region
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='clientAddressForm']//strong[contains(text(),'Област')]/../input"));
        //    }
        //}

        //public IWebElement Area
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='clientAddressForm']//strong[contains(text(),'Община')]/../input"));
        //    }
        //}

        //public IWebElement Zip
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='clientAddressForm']/div[1]/div[2]/div[4]/input"));
        //    }
        //}

        //public IWebElement Neighbourhood
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='clientAddressForm']/div[1]/div[3]/div[1]/p-autocomplete/span/input"));
        //    }
        //}

        //public IWebElement NeighbourhoodCurrent
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='clientAddressForm']/div[1]/div[3]/div[1]/p-autocomplete/span/div/ul/li"));
        //    }
        //}

        //public IWebElement StreetName
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='clientAddressForm']/div[1]/div[3]/div[2]/p-autocomplete/span/input"));
        //    }
        //}

        //public IWebElement StreetBeganska
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[@id='clientAddressForm']/div[1]/div[3]/div[2]/p-autocomplete/span/div/ul/li[1]"));
        //    }
        //}

        //public IWebElement StreetNumber
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[contains(text(), '№')]/../input"));
        //    }
        //}

        //public IWebElement Block
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[contains(text(), 'Бл')]/../input"));
        //    }
        //}

        //public IWebElement Entrence
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[contains(text(), 'Вх')]/../input"));
        //    }
        //}

        //public IWebElement Floor
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[contains(text(), 'Ет')]/../input"));
        //    }
        //}

        //public IWebElement ApartmentNumber
        //{
        //    get
        //    {
        //        return this.FindElement(By.XPath("//*[contains(text(), 'Ап')]/../input"));
        //    }
        //}

        //public SelectElement HomeTypeSelect
        //{
        //    get
        //    {
        //        return new SelectElement(this.FindElement(By.XPath("//*[@id='clientAddressForm']/div[1]/div[5]/div[1]/select")));
        //    }
        //}

        //public SelectElement ResidencePeriods
        //{
        //    get
        //    {
        //        return new SelectElement(this.FindElement(By.XPath("//*[@id='clientAddressForm']/div[1]/div[5]/div[2]/select")));
        //    }
        //}

        //public IWebElement CheckDifferentAddresses
        //{
        //    get
        //    {
        //        return this.FindElement(By.Id("differentAddresses"));
        //    }
        //}

        //public IWebElement CheckDifferentAddresses
        //{
        //    get
        //    {
        //        return this.FindElement(By.Id("differentAddresses"));
        //    }
        //}
    }
}
