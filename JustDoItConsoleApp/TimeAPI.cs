using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace JustDoItConsoleApp
{
    public class TimeAPI
    {


        private HttpClient client = new HttpClient();

        private Dictionary<string, string> info = new Dictionary<string, string>();


        public async void getInfo()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://worldtimeapi.org/api/timezone/europe/zurich");
    
        HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string body = await response.Content.ReadAsStringAsync();


            info = JsonConvert.DeserializeObject<Dictionary<string, string>>(body);
            showInfo();

        }

        private void showInfo()
        {
            Console.WriteLine("TimeApi has sent back the following info: " + info["datetime"] + info["timezone"]);
        }

    }
}