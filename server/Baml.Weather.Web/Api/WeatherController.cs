using System;
using System.Threading.Tasks;
using Baml.Weather.Web.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Baml.Weather.Web.Api
{
    [Route("api/weather")]
    public class WeatherController : Controller
    {
        [HttpGet("getbylocation/{location}")]
        public Task<LocationWeather> GetByLocation(string location)
        {
            return Task.FromResult(new LocationWeather(){LastFetched = DateTimeOffset.Now, Location = location});
        }
    }
}