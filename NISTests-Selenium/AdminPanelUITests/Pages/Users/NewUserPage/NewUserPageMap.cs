using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AdminPanelUITests.Pages.Users.NewUserPage
{
    public partial class NewUserPage
    {
        public IWebElement Username
        {
            get
            {
                return this.FindElement(By.Id("username"));
            }
        }

        public IWebElement Password
        {
            get
            {
                return this.FindElement(By.Id("password"));
            }
        }

        public IWebElement GeneratePassword
        {
            get
            {
                return this.FindElement(By.Id("gen_new_password"));
            }
        }

        public SelectElement SelectStatus
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='status']/div/div[1]/select")));
            }
        }

        public IWebElement IsBlocked
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='is_locked']/div/div[2]"));
            }
        }

        public IWebElement Email
        {
            get
            {
                return this.FindElement(By.Id("email"));
            }
        }

        public IWebElement PhoneNumber
        {
            get
            {
                return this.FindElement(By.Id("phone-number"));
            }
        }

        public IWebElement FirstName
        {
            get
            {
                return this.FindElement(By.Id("first_name"));
            }
        }

        public IWebElement SecondName
        {
            get
            {
                return this.FindElement(By.Id("second_name"));
            }
        }

        public IWebElement LastName
        {
            get
            {
                return this.FindElement(By.Id("last_name"));
            }
        }

        public SelectElement Department
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='department']/div/div[1]/select")));
            }
        }

        public SelectElement Domain
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='domain']/div/div[1]/select")));
            }
        }

        public SelectElement Job
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='job']/div/div[1]/select")));
            }
        }

        public SelectElement Position
        {
            get
            {
                return new SelectElement(this.FindElement(By.XPath("//*[@id='position']/div/div[1]/select")));
            }
        }

        public IWebElement Roles
        {
            get
            {
                return this.FindElement(By.XPath("//*[@id='roles']/div/div[3]"));
            }
        }

        public IWebElement RolesKE
        {
            get
            {
                return this.FindElement(By.XPath("//*[contains(text(), 'Кредитен Експерт')]"));
            }
        }

        public IWebElement Create
        {
            get
            {
                return this.FindElement(By.XPath("//button[contains(text(), 'Създай Потребител')]"));
            }
        }
    }
}
