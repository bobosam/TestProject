// <copyright file="PostMethodDefinition.cs" company="MyCompany.com">
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
    /// Public class PostMethodDefinition contains all Post step definition methods.
    /// </summary>
    [Binding]
    public sealed class PostMethodDefinition
    {
        /// <summary>
        /// Gets or sets property contains the error.
        /// </summary>
        /// <value>Current error.</value>
        public static Error Err { get; set; }

        /// <summary>
        /// Gets a book data from excel file.
        /// Sends a Post request from CreatePostRequest method.
        /// </summary>
        /// <param name="name">Key data parameter.</param>
        [When(@"Add book (.*)")]
        public void AddBook(string name)
        {
            var booksData = AccessExcelData.GetTestData<Book>("Name", name, "Books", EndpointsConstants.BooksXlsxFilename);
            if (name == "maxInt")
            {
                booksData.Id = int.MaxValue.ToString();
            }

            string json = JsonConvert.SerializeObject(booksData);
            string url = EndpointsConstants.BaseUrl + "/api/books";
            var response = PostHelpMethods.CreatePostRequest(url, json);

            if (response.StatusCode != HttpStatusCode.OK)
            {
                var responseJson = response.Content.ReadAsStringAsync().Result;
                Err = JsonConvert.DeserializeObject<Error>(responseJson);
            }
        }

        /// <summary>
        /// Gets a book data from excel file.
        /// Sends a Get request from ReturnBooksById method.
        /// Asserts saved data.
        /// </summary>
        /// <param name="name">Filtering parameter.</param>
        [Then(@"Book (.*) must be save")]
        public void BookWithCurrentIdSaved(string name)
        {
            var booksData = AccessExcelData.GetTestData<Book>("Name", name, "Books", EndpointsConstants.BooksXlsxFilename);
            if (name == "maxInt")
            {
                booksData.Id = int.MaxValue.ToString();
            }

            if (name == "tooBigId")
            {
                long id = int.MaxValue;
                booksData.Id = (id + 1).ToString();
            }

            var response = GetHelpMethods.ReturnBooksById(booksData.Id);
            var responseJson = response.Content.ReadAsStringAsync().Result;
            var book = JsonConvert.DeserializeObject<Book>(responseJson);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(booksData.Id, book.Id, "Id");
            Assert.AreEqual(booksData.Title, book.Title, "Title");
            Assert.AreEqual(booksData.Author, book.Author, "Author");
            Assert.AreEqual(booksData.Description, book.Description, "Description");
        }

        /// <summary>
        /// Gets string format from excel file.
        /// Checks response error message.
        /// </summary>
        /// <param name="id">Filtering parameter.</param>
        [Then(@"Must show error for Id '(.*)'")]
        public void ShowErrorExistingId(string id)
        {
            var errorFormat = AccessExcelData.GetTestData<Error>("Name", "existingID", "Errors", EndpointsConstants.BooksXlsxFilename);
            var expectedMessage = string.Format(errorFormat.Message, id);

            Assert.AreEqual(expectedMessage, Err.Message);
        }

        /// <summary>
        /// Gets the error message from excel file.
        /// Checks response error message.
        /// </summary>
        [Then(@"Must show Id error")]
        public void ShowIdError()
        {
            var expectedError = AccessExcelData.GetTestData<Error>("Name", "wrongId", "Errors", EndpointsConstants.BooksXlsxFilename);
            var expectedMessage = expectedError.Message;
            expectedMessage = expectedMessage.Replace("\\r\\n", "\r\n");

            Assert.AreEqual(expectedMessage, Err.Message);
        }

        /// <summary>
        /// Gets the error essage from excel file.
        /// Assert response error message.
        /// </summary>
        [Then(@"Must show longer author error")]
        public void ShowLongerAuthorError()
        {
            var expectedError = AccessExcelData.GetTestData<Error>("Name", "wrongAuthor", "Errors", EndpointsConstants.BooksXlsxFilename);
            var expectedMessage = expectedError.Message;
            expectedMessage = expectedMessage.Replace("\\r\\n", "\r\n");

            Assert.AreEqual(expectedMessage, Err.Message);
        }

        /// <summary>
        /// Gets the error message from excel file.
        /// Assert response error message.
        /// </summary>
        [Then(@"Must show required author error")]
        public void ShowRequiredAuthorError()
        {
            var expectedError = AccessExcelData.GetTestData<Error>("Name", "requiredAuthor", "Errors", EndpointsConstants.BooksXlsxFilename);
            var expectedMessage = expectedError.Message;
            expectedMessage = expectedMessage.Replace("\\r\\n", "\r\n");

            Assert.AreEqual(expectedMessage, Err.Message);
        }

        /// <summary>
        /// Gets the error message from excel file.
        /// Assert response error message.
        /// </summary>
        [Then(@"Must show required title error")]
        public void ShowRequiredTitleError()
        {
            var expectedError = AccessExcelData.GetTestData<Error>("Name", "requiredTitle", "Errors", EndpointsConstants.BooksXlsxFilename);
            var expectedMessage = expectedError.Message;
            expectedMessage = expectedMessage.Replace("\\r\\n", "\r\n");

            Assert.AreEqual(expectedMessage, Err.Message);
        }

        /// <summary>
        /// Gets the error message from excel file.
        /// Assert response error message.
        /// </summary>
        [Then(@"Must show longer title error")]
        public void ShowLongerTitleError()
        {
            var expectedError = AccessExcelData.GetTestData<Error>("Name", "wrongTitle", "Errors", EndpointsConstants.BooksXlsxFilename);
            var expectedMessage = expectedError.Message;
            expectedMessage = expectedMessage.Replace("\\r\\n", "\r\n");

            Assert.AreEqual(expectedMessage, Err.Message);
        }
    }
}
