namespace CRMUITests.Pages.Request.RequestMainPage
{
    using System;
    using System.Collections.Generic;

    using DataDriven.Models.CRM.Request;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    
    public partial class RequestMainPage
    {
        public void CheckGridOrderByRequestID(List<IWebElement> elements)
        {
            Assert.IsTrue(elements.Count > 0, "There are no requests in the table.");
            for (int i = 1; i < elements.Count; i++)
            {
                Assert.IsTrue(int.Parse(elements[i].Text) < int.Parse(elements[i - 1].Text));
            }
        }

        public void CheckGridOrderByCreatedOn(List<IWebElement> createdOnElements)
        {
            Assert.IsTrue(createdOnElements.Count > 0, "There are no requests in the table.");
            for (int i = 1; i < createdOnElements.Count; i++)
            {
                DateTime prevousDate = DateTime.ParseExact(createdOnElements[i - 1].Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                DateTime currentDate = DateTime.ParseExact(createdOnElements[i].Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);

                Assert.IsTrue(currentDate <= prevousDate);
            }
        }

        public void CheckRequestDetailsData(RequestData data)
        {
            Assert.AreEqual(("№: " + data.RequestId).Trim(), this.DetailsRequestId.Text, "RequestId");
            Assert.AreEqual(("Статус: " + data.Status).Trim(), this.DetailsStatus.Text, "Status");
            Assert.AreEqual(("Източник: " + data.Source).Trim(), this.DetailsSource.Text, "Source");
            Assert.AreEqual(("Текущ приоритет: " + data.Priority).Trim(), this.DetailstPriority.Text, "Priority");
            Assert.AreEqual(("Име: " + data.Name).Trim(), this.DetailsClientName.Text, "Client name");
            Assert.AreEqual(("Телефон: " + data.Phone).Trim(), this.DetailsClientPhone.Text, "Phone");
            Assert.AreEqual(("Тип клиент: " + data.ClientType).Trim(), this.DetailsClientType.Text, "Client type");
            Assert.AreNotEqual("Офис:", this.DetailsOfficeName.Text.Trim(), "Office");
            Assert.AreNotEqual("Регион:", this.DetailsOfficeRegion.Text.Trim(), "Region");
            Assert.AreNotEqual("Област:", this.DetailsOfficeArea.Text.Trim(), "Area");
            Assert.AreNotEqual("Район:", this.DetailsOfficeSubarea.Text.Trim(), "Subarea");

            // TODO Assert.AreNotEqual("KE:", this.DetailsKEName.Text.Trim(), "KE Name");
            Assert.AreNotEqual("Код:", this.DetailsKECode.Text.Trim(), "KE code");
        }

        public void CheckRequestModalData(RequestData data)
        {
            Assert.AreEqual(("Номер на заявка: " + data.RequestId).Trim(), this.ModalDetailsRequestNumber.Text, "RequestId");
            Assert.AreEqual(("Статус: " + data.Status).Trim(), this.ModalDetailsStatus.Text, "Status");
            Assert.AreEqual(("Източник: " + data.Source).Trim(), this.ModalDetailsSource.Text, "Source");
            Assert.AreEqual(("Текущ приоритет: " + data.Priority).Trim(), this.ModalDetailsPriority.Text, "Priority");
            Assert.AreEqual(("Тип клиент: " + data.ClientType).Trim(), this.ModalDetailsClientType.Text, "Client type");
            Assert.AreEqual("Дата на постъпване: " + data.CreatedOn.Trim(), this.ModalDetailsCreatedOn.Text, "Created on");

            // TODO Assert.AreNotEqual("KE:", this.ModalDetailsOperatorName.Text.Trim(), "KE Name");
            Assert.IsTrue(this.ModalDetailsHistory.Text.StartsWith("Последно извършено действие:"));
        }
    }
}
