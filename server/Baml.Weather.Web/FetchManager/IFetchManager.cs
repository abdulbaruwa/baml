using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Baml.Weather.Web.Config;
using Baml.Weather.Web.Core.Dtos;
using Baml.Weather.Web.Core.Models;
using Newtonsoft.Json;
using Refit;

namespace Baml.Weather.Web.FetchManager
{
    public interface IFetchManager
    {
        Task<IEnumerable<WeatherDto>> FetchSyncWeatherForLocation(int locationId);
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

        public async Task<IEnumerable<WeatherDto>> FetchSyncWeatherForLocation(int locationId)
        {
            
            var json = await RestService.For<IOpenWeatherMapApi>(_openWeatherSettings.Url).GetMap(524901, _openWeatherSettings.Key);
            var locationWeather = JsonConvert.DeserializeObject<LocationWeather>(json);
            var weatherDtos = MapLocationWeatherToDto(locationWeather);
            return weatherDtos;
            //return new LocationWeather() {LastFetched = DateTimeOffset.Now, Location = "Winston"};
        }

        public List<WeatherDto> MapLocationWeatherToDto(LocationWeather locationWeather)
        {
            var grouped = locationWeather.list.GroupBy(n => n.Day);
            var weatherDtos = new List<WeatherDto>();
            var locale = locationWeather.city.name;
            var localeId = locationWeather.city.id;
            foreach (var list in grouped)
            {
                var rootItem = list.First();
                var weatherDto = new WeatherDto
                {
                    WeatherDay = rootItem.Day.ToShortDateString(),
                    Locale = locale,
                    LocaleId = localeId
                };

                var details = list.Select(x => new WeatherDetailDto()
                {
                    Temperature = x.main.temp,
                    Humidity = x.main.humidity,
                    Wind = x.wind.speed,
                    WindDirection = x.wind.deg,
                    ShortDescription = x.weather.FirstOrDefault()?.description,
                    DayTime = x.DateTimeOffset,
                    Precipitation = x.snow.ThreeHourVolume,
                }).ToArray();

                weatherDto.WeatherDetailDtos = details;
                weatherDtos.Add(weatherDto);
            }

            return weatherDtos;
        }
    }
}