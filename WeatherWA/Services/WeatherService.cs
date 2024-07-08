using System.Text.Json;
using WeatherWA.Models;
using static System.Net.WebRequestMethods;
namespace WeatherWA.Services;

    public class WeatherService
    {
        private string ApiKey = "6b0ae7efc91b3293aa75c28ecf29ba81";
        private string Url = "https://api.openweathermap.org/data/2.5/weather";
        public async Task<Rootobject> Search(string CityName)
        { 
            var httpClient = new HttpClient();
            string WeatherUrl = $"{Url}?q={CityName}&appid={ApiKey}";
            var response = await httpClient.GetAsync(WeatherUrl);
            var json= await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Rootobject>(json);
            return result;
        }
    }

