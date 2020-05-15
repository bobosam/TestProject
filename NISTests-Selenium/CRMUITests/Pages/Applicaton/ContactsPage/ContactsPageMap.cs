namespace CRMUITests.Pages.Applicaton.ContactsPage
{
    using System.Collections.Generic;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class ContactsPage
    {
        public IWebElement MobilePhone
        {
            get
            {
                return this.FindElement(By.Id("mobilePhoneNumber0"));
            }
        }

        public IWebElement StationPhone
        {
            get
            {
                return this.FindElement(By.Id("otherNumber"));
            }
        }

        public IWebElement Email
        {
            get
            {
                return this.FindElement(By.Id("mail"));
            }
        }

        public List<IWebElement> PersonsPhones
        {
            get
            {
                List<IWebElement> phones = new List<IWebElement>(this.FindElements(By.XPath("//input[contains(@id, 'firstPersonNumber')]")));

                return phones;
            }
        }

        public List<IWebElement> PersonsNames
        {
            get
            {
                List<IWebElement> names = new List<IWebElement>(this.FindElements(By.XPath("//input[contains(@id, 'ContactPersonName')]")));

                return names;
            }
        }

        public List<SelectElement> PersonsType
        {
            get
            {
                List<SelectElement> typeSelects = new List<SelectElement>();
                List<IWebElement> personsType = new List<IWebElement>(this.FindElements(By.Name("options")));
                foreach (var person in personsType)
                {
                    SelectElement element = new SelectElement(person);
                    typeSelects.Add(element);
                }

                return typeSelects;
            }
        }
    }
}
