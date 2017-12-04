using System;
using System.Threading.Tasks;
using Baml.Weather.Web.Config;
using Baml.Weather.Web.Core.Models;
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
        private AppSettings _appSettings;

        public FetchManager(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }

        public async Task<LocationWeather> FetchSyncWeatherForLocation(int locationId)
        {
            var json = await RestService.For<IOpenWeatherMapApi>("http://samples.openweathermap.org/data/2.5").GetMap(524901, _appSettings.AppKey.Key);
            return new LocationWeather() {LastFetched = DateTimeOffset.Now, Location = "Winston"};
        }
    }
}