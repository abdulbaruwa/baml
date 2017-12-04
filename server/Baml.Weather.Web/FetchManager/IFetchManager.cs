using System;
using System.Threading.Tasks;
using Baml.Weather.Web.Core.Models;

namespace Baml.Weather.Web.FetchManager
{
    public interface IFetchManager
    {
        Task<LocationWeather> FetchSyncWeatherForLocation(int locationId);
    }

    public class FetchManager : IFetchManager
    {
        public Task<LocationWeather> FetchSyncWeatherForLocation(int locationId)
        {
            return Task.FromResult(new LocationWeather() {LastFetched = DateTimeOffset.Now, Location = "Windsor"});
        }
    }
}