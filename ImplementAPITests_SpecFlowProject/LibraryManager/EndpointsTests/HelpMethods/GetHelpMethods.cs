// <copyright file="GetHelpMethods.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project</summary>
// <author>Boyko Andonov</author>
namespace EndpointsTests.HelpMethods
{
    using System.Net.Http;

    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Public class GetHelpMethods contains all Get help methods.
    /// </summary>
    public class GetHelpMethods
    {
        /// <summary>
        /// Send a Get request.
        /// </summary>
        /// <param name="urlString">String value.</param>
        /// <returns>Server response.</returns>
        internal static HttpResponseMessage CreateGetRequest(string urlString)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(urlString).Result;

            return response;
        }

        /// <summary>
        /// Sends a Get request.
        /// </summary>
        /// <returns>Counts of all books in DB.</returns>
        internal static int ReturnAllBooksCount()
        {
            var getAllBooksUrl = EndpointsConstants.BaseUrl + "/api/books";
            var response = GetHelpMethods.CreateGetRequest(getAllBooksUrl);
            var responseJson = response.Content.ReadAsStringAsync().Result;
            JArray arr = JArray.Parse(responseJson);

            return arr.Count;
        }

        /// <summary>
        /// Sends a Get request.
        /// </summary>
        /// <param name="title">Filtering parameter.</param>
        /// <returns>Book array containing this title.</returns>
        internal static JArray ReturnBooksByTitle(string title)
        {
            var getAllBooksUrl = EndpointsConstants.BaseUrl + "/api/books?title=" + title;
            var response = GetHelpMethods.CreateGetRequest(getAllBooksUrl);
            var responseJson = response.Content.ReadAsStringAsync().Result;
            JArray arr = JArray.Parse(responseJson);

            return arr;
        }

        /// <summary>
        /// Sends a Get request.
        /// </summary>
        /// <param name="id">Filtering parameter.</param>
        /// <returns>Server response.</returns>
        internal static HttpResponseMessage ReturnBooksById(string id)
        {
            var getAllBooksUrl = EndpointsConstants.BaseUrl + "/api/books/" + id;
            var response = GetHelpMethods.CreateGetRequest(getAllBooksUrl);
                        
            return response;
        }
    }
}
