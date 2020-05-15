namespace CRMUITests.Pages.Applicaton.AdditionalInfoPage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public partial class AdditionalInfoPage
    {
        public SelectElement MaritalStatus
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='marital - status - drop - down']/div/div[1]/select")));
            }
        }

        public IWebElement ChildrenCount
        {
            get
            {
                return this.FindElement(By.Id("children-below-eighteen"));
            }
        }

        public SelectElement ЕducationDegrees
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='education - degree - drop - down']/div/div[1]/select")));
            }
        }

        public SelectElement HighPublicOfficial
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='high -public-officer-drop-down']/div/div[1]/select")));
            }
        }

        public SelectElement JDConnectionPersonType
        {
            get
            {
                return new SelectElement(this.FindElement(By.Name("connection-with-client")));
            }
        }
    }
}
