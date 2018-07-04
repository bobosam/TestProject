// <copyright file="PutHelpMethods.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project</summary>
// <author>Boyko Andonov</author>
namespace EndpointsTests.HelpMethods
{
    using System.Net.Http;
    using System.Text;

    /// <summary>
    /// Public class PutHelpMethods contains all Put help methods.
    /// </summary>
    public class PutHelpMethods
    {
        /// <summary>
        /// Sends a Put request.
        /// </summary>
        /// <param name="urlString">URL string.</param>
        /// <param name="putData">Books data.</param>
        /// <returns>Server response.</returns>
        internal static HttpResponseMessage CreatePutRequest(string urlString, string putData)
        {
            var httpClient = new HttpClient();
            var content = new StringContent(putData, Encoding.UTF8, "application/json");
            var response = httpClient.PutAsync(urlString, content).Result;

            return response;
        }
    }
}
