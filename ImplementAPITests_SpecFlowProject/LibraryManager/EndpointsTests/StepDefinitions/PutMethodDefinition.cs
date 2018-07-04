// <copyright file="PutMethodDefinition.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project</summary>
// <author>Boyko Andonov</author>
namespace EndpointsTests.StepDefinitions
{
    using System.Net;

    using DataDriven;
    using DataDriven.Models;
    using EndpointsTests.HelpMethods;
    using Newtonsoft.Json;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Public class PutMethodDefinition contains all Put step definition methods.
    /// </summary>
    [Binding]
    public sealed class PutMethodDefinition
    {
        /// <summary>
        /// Gets the books data from excel file.
        /// Sends a Put request from CreatePutRequest method.
        /// </summary>
        /// <param name="oldBook">Old book data.</param>
        /// <param name="newBook">New book data.</param>
        [When(@"Change (.*) with (.*)")]
        public void ChangeBook(string oldBook, string newBook)
        {
            var newData = AccessExcelData.GetTestData<Book>("Name", newBook, "Books", EndpointsConstants.BooksXlsxFilename);
            var oldData = AccessExcelData.GetTestData<Book>("Name", oldBook, "Books", EndpointsConstants.BooksXlsxFilename);
            if (newBook == "maxInt")
            {
                newData.Id = int.MaxValue.ToString();
            }

            if (newBook == "tooBigId")
            {
                long currentId = int.MaxValue;
                newData.Id = (currentId + 1).ToString();
            }

            string json = JsonConvert.SerializeObject(newData);
            string url = EndpointsConstants.BaseUrl + "/api/books/" + oldData.Id;
            var response = PutHelpMethods.CreatePutRequest(url, json);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var responseJson = response.Content.ReadAsStringAsync().Result;
                PostMethodDefinition.Err = JsonConvert.DeserializeObject<Error>(responseJson);
            }
        }
    }
}
