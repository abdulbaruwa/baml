using System;
using System.Threading.Tasks;
using Baml.Weather.Web.Config;
using Baml.Weather.Web.Core.Models;
using Baml.Weather.Web.FetchManager;
using Microsoft.AspNetCore.Mvc;

namespace Baml.Weather.Web.Api
{
    [Route("api/weather")]
    public class WeatherController : Controller
    {
        private readonly IFetchManager _fetchManager;
        private readonly AppSettings _appSettings;
        public WeatherController(IFetchManager fetchManager, AppSettings appSettings)
        {
            _fetchManager = fetchManager;
            _appSettings = appSettings;
        }

        [HttpGet("getbylocation/{location}")]
        public Task<LocationWeather> GetByLocation(string location)
        {
             
            return _fetchManager.FetchSyncWeatherForLocation(3);
        }
    }
}