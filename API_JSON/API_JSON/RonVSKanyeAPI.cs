using System;
using Newtonsoft.Json.Linq;

namespace API_JSON
{
	public class RonVSKanyeAPI
	{
        public static void Convo()
        {
            var client = new HttpClient();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Kanye says \n {GetKanyeQuote(client)}\n");
                Console.WriteLine();
                Console.WriteLine($"Ron says \n {GetRonQuote(client)}\n");

            }
        }
        private static string GetRonQuote(HttpClient client)
        {

            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
            var ronResponse = client.GetStringAsync(ronURL).Result;
            var ronQuote = ronResponse.Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();
            return ronQuote;
        }

        private static string GetKanyeQuote(HttpClient client)
        {
            var jsonText = client.GetStringAsync("https://api.kanye.rest/").Result;

            var quote = JObject.Parse(jsonText).GetValue("quote").ToString();
            return quote;
        }

    }
}

