using System;
using System.Threading.Tasks;
using Baml.Weather.Web.Config;
using Baml.Weather.Web.Core.Models;
using Newtonsoft.Json;
using Refit;

namespace Baml.Weather.Web.FetchManager
{
    public interface IFetchManager
    {
        Task<LocationWeather> FetchSyncWeatherForLocation(int locationId);
    }

    public interface IOpenWeatherMapApi
    {
        // http://samples.openweathermap.org/data/2.5/forecast?id=524901&appid=b1b15e88fa797225412429c1c50c122a1
        [Get("/forecast?id={locationId}&appid={appId}")]
        Task<string> GetMap(int locationId, string appId);
    }

    public class FetchManager : IFetchManager
    {
        private readonly OpenWeatherSettings _openWeatherSettings;

        public FetchManager(OpenWeatherSettings openWeatherSettings)
        {
            _openWeatherSettings = openWeatherSettings;
        }

        public async Task<LocationWeather> FetchSyncWeatherForLocation(int locationId)
        {
            var json = await RestService.For<IOpenWeatherMapApi>(_openWeatherSettings.Url).GetMap(524901, _openWeatherSettings.Key);
            var locationWeather = JsonConvert.DeserializeObject<LocationWeather>(json);
            return locationWeather;
            //return new LocationWeather() {LastFetched = DateTimeOffset.Now, Location = "Winston"};
        }
    }
}