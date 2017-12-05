using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Baml.Weather.Web.Core.Dtos;

namespace Baml.Weather.Web.FetchManager
{
    public interface IFetchManager
    {
        Task<IEnumerable<WeatherDto>> FetchSyncWeatherForLocation(int locationId);
    }
}