using System;
using System.Net;
using System.Net.Http;

namespace JustDoItConsoleApp
{
    class Program
    {
        private const string URL = "https://worldtimeapi.org/api/timezone/europe/zurich";
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            UI UI = new UI();
            //TimeAPI();

            UI.StartUi();
        }
        //private static string ShowApi()
        //{
            //Console.WriteLine("$timestamp");
        //}
    }
}
