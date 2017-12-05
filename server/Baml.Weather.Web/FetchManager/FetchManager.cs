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

                var details = list.Select(x => new TimedWeatherDetail()
                {
                    Temperature = x.main.temp,
                    Humidity = x.main.humidity,
                    Wind = x.wind.speed,
                    WindDirection = x.wind.deg,
                    ShortDescription = x.weather.FirstOrDefault()?.description,
                    DayTime = x.DateTimeOffset,
                    Precipitation = x.snow.ThreeHourVolume,
                }).ToArray();

                weatherDto.TimedWeatherDetail = details;
                weatherDtos.Add(weatherDto);
            }

            return weatherDtos;
        }
    }
}