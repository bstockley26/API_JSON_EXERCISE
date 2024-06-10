using System;
using Newtonsoft.Json.Linq;

namespace API_JSON
{
	public class OpenWeatherMapAPI
	{
        public static void GetTemp()
        {
            var appsettingsText = File.ReadAllText("appsettings.json");

            var apiKey = JObject.Parse(appsettingsText)["apiKey"].ToString();


            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?zip=28173,&appid={apiKey}&units=Imperial";

            var client = new HttpClient();

            var jsonText = client.GetStringAsync(weatherURL).Result;

            var weatherObj = JObject.Parse(jsonText);

            Console.WriteLine($"Ron says the temperature in Charlotte is {weatherObj["main"]["temp"]}degrees");

        }
    }
}

