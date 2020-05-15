namespace CRMUITests.Pages.Applicaton.ContactsPage
{
    using DataDriven.Models.CRM.Applicaton;
    using OpenQA.Selenium;
   
    public partial class ContactsPage : ApplicationMainPage
    {
        public ContactsPage(IWebDriver driver) : base(driver)
        {
        }

        public void FillContacts(Contacts contacts)
        {
            //this.FillCDContacts(contacts);
            //this.Type(this.PersonsPhones[0], contacts.FirstContactPersonPhone);
            //this.Type(this.PersonsNames, contacts.FirstContactPersonName);
            //this.SelectByText(this.PersonsType[0], contacts.FirstContactPersonType);
            //this.Type(this.PersonsPhones[1], contacts.SecondContactPersonPhone);
            //this.Type(this.SecondPersonName, contacts.SecondContactPersonName);
            //this.SelectByText(this.PersonsType[1], contacts.SecondContactPersonType);
        }

        public void FillCDContacts(Contacts contacts)
        {
            this.Type(this.MobilePhone, contacts.MobilePhone);
            this.Type(this.StationPhone, contacts.StationPhone);
            this.Type(this.Email, contacts.EmailAddress);
        }
    }
}
