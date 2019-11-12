using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RazorTest.Helpers
{
    public static class HttpClientHelper
    {
        //public static HttpClient 

        public async static Task Test()
        {
            var definition = new[] { new
            {
                Date = DateTime.Now,
                TemperatureC = 0,
                TemperatureF = 0,
                Summary = ""
            }};

            using var client = new HttpClient();

            var response = await client.GetAsync("https://localhost:44346/weatherforecast");
            var content = response.Content;
            var stringContent = await content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeAnonymousType(stringContent, definition);
        }
    }
}
