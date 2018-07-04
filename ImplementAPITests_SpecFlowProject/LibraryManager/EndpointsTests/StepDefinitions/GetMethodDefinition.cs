// <copyright file="GetMethodDefinition.cs" company="MyCompany.com">
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
    /// Public class GetMethodDefinition contains all Get step definition methods.
    /// </summary>
    [Binding]
    public sealed class GetMethodDefinition
    {
        /// <summary>
        /// Sends a Get request from ReturnBooksByTitle method.
        /// </summary>
        /// <param name="title">Filtering parameter.</param>
        /// <param name="count">Expected count.</param>
        [Then(@"Books count by title '(.*)' must be '(.*)'")]
        public void AssertBooksCountByTitle(string title, string count)
        {
            var responseArr = GetHelpMethods.ReturnBooksByTitle(title);

            Assert.AreEqual(int.Parse(count), responseArr.Count);
        }

        /// <summary>
        /// Sends a Get request from ReturnBooksByTitle method.
        /// Checks server response for books title.
        /// </summary>
        /// <param name="title">Filtering parameter.</param>
        [Then(@"Books title contain '(.*)'")]
        public void AssertTitle(string title)
        {
            var responseArr = GetHelpMethods.ReturnBooksByTitle(title);
            foreach (var book in responseArr)
            {
                var result = JsonConvert.DeserializeObject<Book>(book.ToString());

                Assert.True(result.Title.Contains(title));
            }
        }

        /// <summary>
        /// Sends a Get request from ReturnBooksById method.
        /// Checks server response for the book title.
        /// </summary>
        /// <param name="id">Filtering parameter.</param>
        [Then(@"Get a book with id '(.*)'")]
        public void GetBookById(string id)
        {
            var response = GetHelpMethods.ReturnBooksById(id);
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var book = JsonConvert.DeserializeObject<Book>(responseJson);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(id, book.Id.ToString());
        }

        /// <summary>
        /// Sends a Get request with invalid Id.
        /// Checks response error.
        /// </summary>
        /// <param name="id">Filtering parameter.</param>
        [Then(@"Get a book with invalid id '(.*)'")]
        public void GetBookByInvalidId(string id)
        {
            var response = GetHelpMethods.ReturnBooksById(id);
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var error = JsonConvert.DeserializeObject<Error>(responseJson);
            var messageFormat = AccessExcelData.GetTestData<Error>("Name", "missingId", "Errors", EndpointsConstants.BooksXlsxFilename).Message;
            var expectedMessage = string.Format(messageFormat, id);

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.AreEqual(expectedMessage, error.Message);
        }
    }
}
