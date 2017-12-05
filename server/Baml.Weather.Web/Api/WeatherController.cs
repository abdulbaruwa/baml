using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Baml.Weather.Web.Config;
using Baml.Weather.Web.Core.Dtos;
using Baml.Weather.Web.Core.Models;
using Baml.Weather.Web.FetchManager;
using Microsoft.AspNetCore.Mvc;

namespace Baml.Weather.Web.Api
{
    [Route("api/weather")]
    public class WeatherController : Controller
    {
        private readonly IFetchManager _fetchManager;
        public WeatherController(IFetchManager fetchManager)
        {
            _fetchManager = fetchManager;
        }

        [HttpGet("getbylocation/{location}")]
        public Task<IEnumerable<WeatherDto>> GetByLocation(string location)
        {
            return _fetchManager.FetchSyncWeatherForLocation(3);
        }
    }
}