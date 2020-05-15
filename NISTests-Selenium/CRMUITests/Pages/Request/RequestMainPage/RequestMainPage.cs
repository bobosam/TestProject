namespace CRMUITests.Pages.Request.RequestMainPage
{
    using System.Threading;

    using DataDriven.Models.CRM.Request;
    using OpenQA.Selenium;
    using BaseUITests;

    public partial class RequestMainPage : BasePage
    {
        public RequestMainPage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToRedistribution()
        {
            this.FirstRequestID.Click();
            Thread.Sleep(500);
            this.DetailsActions.Click();
            this.DetailsActionsRedistribution.Click();
        }

        public RequestData GetFirstRequestData()
        {
            RequestData requestData = new RequestData();

            requestData.ClientType = this.FirstRequestClientType.Text;
            requestData.CreatedOn = this.FirstRequestCreatedOn.Text;
            requestData.Name = this.FirstRequestName.Text;
            requestData.Phone = this.FirstRequestPhoneNumber.Text;
            requestData.Priority = this.FirstRequestPriority.Text;
            requestData.RequestId = this.FirstRequestID.Text;
            requestData.Source = this.FirstRequestSource.Text;
            requestData.Status = this.FirstRequestStatus.Text;

            return requestData;
        }
    }
}
