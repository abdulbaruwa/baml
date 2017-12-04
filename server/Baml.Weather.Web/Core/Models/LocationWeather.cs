using System;

namespace Baml.Weather.Web.Core.Models
{
    public class LocationWeather
    {
        public string Location { get; set; }
        public DateTimeOffset LastFetched { get; set; }
    }
}