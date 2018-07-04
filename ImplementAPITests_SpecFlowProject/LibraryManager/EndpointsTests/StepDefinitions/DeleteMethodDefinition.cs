// <copyright file="DeleteMethodDefinition.cs" company="MyCompany.com">
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
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    /// <summary>
    /// Public class DeleteMethodDefinition contains all Delete step definition methods.
    /// </summary>
    [Binding]
    public sealed class DeleteMethodDefinition
    {
        /// <summary>
        /// Check for the book by Id.
        /// Sends a Delete request.
        /// Check for the missing book with this Id.
        /// </summary>
        /// <param name="id">Filtering parameter.</param>
        [Then(@"Delete a book with id '(.*)'")]
        public void GetBookById(string id)
        {
            var getResponse = GetHelpMethods.ReturnBooksById(id);
            Assert.AreEqual(HttpStatusCode.OK, getResponse.StatusCode);

            var deleteResponse = DeleteHelpMethods.CreateDeleteRequestById(id);           
            Assert.AreEqual(HttpStatusCode.NoContent, deleteResponse.StatusCode);

            var newGetResponse = GetHelpMethods.ReturnBooksById(id);
            Assert.AreEqual(HttpStatusCode.NotFound, newGetResponse.StatusCode);
        }

        /// <summary>
        /// Sends a Delete request with invalid Id.
        /// Check for error.
        /// </summary>
        /// <param name="id">Invalid Id.</param>
        [Then(@"Delete a book with invalid id '(.*)'")]
        public void GetBookByInvalidId(string id)
        {
            var response = DeleteHelpMethods.CreateDeleteRequestById(id);
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var error = JsonConvert.DeserializeObject<Error>(responseJson);
            var messageFormat = AccessExcelData.GetTestData<Error>("Name", "missingId", "Errors", EndpointsConstants.BooksXlsxFilename).Message;
            var expectedMessage = string.Format(messageFormat, id);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual(expectedMessage, error.Message);
        }
    }
}
