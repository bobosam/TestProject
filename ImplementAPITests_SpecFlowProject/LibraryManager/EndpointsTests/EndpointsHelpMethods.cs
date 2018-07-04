using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EndpointsTests
{
    public class EndpointsHelpMethods
    {
        public static HttpResponseMessage CreateGetRequest(string urlString)
        {
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(urlString).Result;

            return response;
        }

        public static HttpResponseMessage CreateDeleteRequest(string urlString, string token)
        {
            var httpClient = new HttpClient();

            if (token != null)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            }

            var response = httpClient.DeleteAsync(urlString).Result;

            return response;
        }

        public static HttpResponseMessage CreatePostRequest(string urlString, string postData)
        {
            var httpClient = new HttpClient();
            var content = new StringContent(postData, Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(urlString, content).Result;

            return response;
        }

        public static HttpResponseMessage CreatePutRequest(string urlString, string putData, string token)
        {
            var httpClient = new HttpClient();

            if (token != null)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            }

            var content = new StringContent(putData, Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync(urlString, content).Result;

            return response;
        }

        public static int ReturnBooksCount()
        {
            var getAllBooksUrl = EndpointsConstants.BaseUrl + "/api/books";
            var response = EndpointsHelpMethods.CreateGetRequest(getAllBooksUrl);
            var responseJson = response.Content.ReadAsStringAsync().Result;
            JArray arr = JArray.Parse(responseJson);

            return arr.Count;
        }

        public static JArray ReturnBooksByTitle(string title)
        {
            var getAllBooksUrl = EndpointsConstants.BaseUrl + "/api/books?title=" + title;
            var response = EndpointsHelpMethods.CreateGetRequest(getAllBooksUrl);
            var responseJson = response.Content.ReadAsStringAsync().Result;
            JArray arr = JArray.Parse(responseJson);

            return arr;
        }
    }
}
