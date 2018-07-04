// <copyright file="DeleteHelpMethods.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project</summary>
// <author>Boyko Andonov</author>
namespace EndpointsTests.HelpMethods
{
    using System.Net.Http;

    /// <summary>
    /// Public class DeleteHelpMethods contains all Delete help methods.
    /// </summary>
    public class DeleteHelpMethods
    {
        /// <summary>
        /// Sends a Delete request.
        /// </summary>
        /// <param name="id">String value.</param>
        /// <returns>Server response.</returns>
        internal static HttpResponseMessage CreateDeleteRequestById(string id)
        {
            var httpClient = new HttpClient();
            var deleteBookUrl = EndpointsConstants.BaseUrl + "/api/books/" + id;
            var response = httpClient.DeleteAsync(deleteBookUrl).Result;

            return response;
        }
    }
}
