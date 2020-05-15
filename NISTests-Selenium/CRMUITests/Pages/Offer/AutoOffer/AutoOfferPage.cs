namespace CRMUITests.Pages.Offer.AutoOfferPage
{
    using System.Collections.Generic;
    using System.Threading;

    using DataDriven.Models.CRM.Offer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using BaseUITests;
    using System;

    public partial class AutoOfferPage : BasePage
    {
        public AutoOfferPage(IWebDriver driver) : base(driver)
        {
        }

        /// <summary>
        /// Insert Client data in fields and click on button check.
        /// </summary>
        /// <param name="client"></param>
        internal void CheckClientPid(AutoOffer client)
        {
            if (client.IsForigner)
            {
                this.ClientForeigner.Click();
            }

            this.Type(this.ClientPID, client.Pid);

            this.Check.Click();
        }

        /// <summary>
        /// Create Offer with JD.
        /// Insert Joint Debtor data in fields and click on button check.
        /// </summary>
        /// <param name="jointDebtor"></param>
        internal void CheckJDPid(AutoOffer jointDebtor)
        {
            Thread.Sleep(500);
            while (!this.HasCodebtor.Selected)
            {
                this.HasCodebtor.Click();
            }

            if (jointDebtor.IsForigner)
            {
                this.JDForeigner.Click();
            }

            this.Type(this.JDPID, jointDebtor.Pid);

            this.Check.Click();
            this.Check.Click();
        }

        /// <summary>
        /// After checking the Pid click on button "Към Оферти"
        /// </summary>
        internal void GoToAutoOfferPage()
        {
            this.ToAutoOffer.Click();
        }

        /// <summary>
        /// Fillout Client data in Auto offer page.
        /// </summary>
        /// <param name="client"></param>
        internal void FilloutClientData(AutoOffer client)
        {
            this.Type(this.RequeredPayment, client.RequestedPayment);
            this.Type(this.RequeredAmount, client.RequestedLoanAmount);
            this.SelectByText(this.RequeredRate, client.RequestedRate);

            this.Type(this.TotalIncomes, client.TotalIncomes);

            if (client.HasUnofficialIncomes)
            {
                this.HasUnofficialIncomes.Click();
            }

            this.Type(this.OtherIncomes, client.OtherIncomes);
            this.Type(this.TotalDebts, client.TotalDebts);
            this.Type(this.TotalExpenses, client.TotalExpenses);
            this.Type(this.CurrentWorkingTime, client.CurrentJobTimeWorking);
            if (client.IsForigner)
            {
                if (!this.IsForeigner.Selected)
                {
                    this.IsForeigner.Click();
                }
            }

            try
            {
                Assert.IsTrue(!this.Age.GetAttribute("value").Equals(string.Empty), "Field Age is not automatically fillout.");
            }
            catch (System.Exception c)
            {
                List<string> msg = new List<string>();
                msg.Add(c.ToString());
            }

            this.Type(this.FirstName, client.FirstName);
            this.Type(this.SecondName, client.SecondName);
            this.Type(this.LastName, client.LastName);
            this.Type(this.Phone, client.Phone);

            if (client.InternalRefinancing)
            {
                this.InternalRefinancing.Click();

                // TO DO!
            }

            if (client.ExternalRefinancing)
            {
                this.ExternalRefinancing.Click();
                this.Type(this.RefinancingRemainingDebt, client.RemainingDebt);
                this.Type(this.RefinancingMonthlyPayment, client.RemainingDebtPayment);
            }
        }

        /// <summary>
        /// Fillout JD data in Auto offer page.
        /// </summary>
        /// <param name="jointDebtor"></param>
        internal void FilloutJDData(AutoOffer jointDebtor)
        {
            this.Type(this.JDTotalIncomes, jointDebtor.TotalIncomes);
            this.Type(this.JDTotalDebts, jointDebtor.TotalDebts);
            this.Type(this.JDTotalExpenses, jointDebtor.TotalExpenses);
            this.Type(this.JDCurrentWorkingTime, jointDebtor.CurrentJobTimeWorking);
            if (jointDebtor.IsForigner)
            {
                if (!this.JDisForeigner.Selected)
                {
                    this.JDisForeigner.Click();
                }
            }

            try
            {
                Assert.IsTrue(!this.JDAge.GetAttribute("value").Equals(string.Empty), "Field JD Age is not automatically fillout.");
            }
            catch (System.Exception c)
            {
                List<string> msg = new List<string>();
                msg.Add(c.ToString());
            }

            this.Type(this.JDFirstName, jointDebtor.FirstName);
            this.Type(this.JDSecondName, jointDebtor.SecondName);
            this.Type(this.JDLastName, jointDebtor.LastName);
            this.Type(this.JDPhone, jointDebtor.Phone);
        }

        /// <summary>
        /// Clicks on button "Изчисли".
        /// </summary>
        internal void CalculateOfferts()
        {
            this.Calculate.Click();
            Thread.Sleep(1000);
        }

        internal CustomOffer GetOffer(string offerType)
        {
            CustomOffer offer = new CustomOffer();

            // offer.LoanAmount = this.UpsellAmount.Text;
            offer.Product = FindElement(By.XPath(string.Format("//*[@id='offers-table']//*[contains(text(),'{0}')]/../div[2]", offerType))).Text;
            offer.LoanAmount = FindElement(By.XPath(string.Format("//*[@id='offers-table']//*[contains(text(),'{0}')]/../../div[2]", offerType))).Text;
            offer.Rate = FindElement(By.XPath(string.Format("//*[@id='offers-table']//*[contains(text(),'{0}')]/../../div[3]", offerType))).Text;
            offer.Payment = FindElement(By.XPath(string.Format("//*[@id='offers-table']//*[contains(text(),'{0}')]/../../div[4]", offerType))).Text;

            return offer;
        }

        internal void AcceptOffer(string offerType)
        {
            Thread.Sleep(1500);
            FindElement(By.XPath(string.Format("//*[@id='offers-table']//*[contains(text(),'{0}')]/../..//button[contains(text(),'Приеми')]", offerType))).Click();
        }

        internal void PrintSEFOffer(string offerType)
        {
            FindElement(By.XPath(string.Format("//*[@id='offers-table']//*[contains(text(),'{0}')]/../..//button[contains(text(),'Принтирай')]", offerType))).Click();
        }

        internal void RemoveOffer(string offerType)
        {
            FindElement(By.XPath(string.Format("//*[@id='offers-table']//*[contains(text(),'{0}')]/../..//button[contains(text(),'Премахни')]", offerType))).Click();
        }

        

        //internal void SigningUpHand()
        //{
        //    FindElement(By.XPath("//button[contains(text(),'Ръчно на хартиен носител')]")).Click();
        //    Thread.Sleep(750);
        //}

        //internal void SigningUpEl()
        //{
        //    FindElement(By.XPath("//button[contains(text(),'Чрез устройство за ел.подписване')]")).Click();
        //}

        internal void RejectAllOffers()
        {
            this.RejectOffers.Click();
        }

        internal void RejectionReason(string reason)
        {
            this.SelectByText(this.SelectReasonRejection, reason);
            this.Ok.Click();
            Thread.Sleep(500);
        }

        internal void RethinkDecision()
        {
            this.PendingDecision.Click();
            Thread.Sleep(500);
        }
    }
}