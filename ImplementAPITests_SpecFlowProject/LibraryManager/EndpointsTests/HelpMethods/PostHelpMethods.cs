// <copyright file="PostHelpMethods.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project</summary>
// <author>Boyko Andonov</author>
namespace EndpointsTests.HelpMethods
{
    using System.Net.Http;
    using System.Text;

    /// <summary>
    /// Public class PostHelpMethods contains all Post help methods.
    /// </summary>
    public class PostHelpMethods
    {
        /// <summary>
        /// Sends a Post request.
        /// </summary>
        /// <param name="urlString">URL string.</param>
        /// <param name="postData">Books data.</param>
        /// <returns>Server response.</returns>
        internal static HttpResponseMessage CreatePostRequest(string urlString, string postData)
        {
            var httpClient = new HttpClient();
            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(urlString, content).Result;

            return response;
        }
    }
}
