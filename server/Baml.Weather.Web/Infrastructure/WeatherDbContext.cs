using Baml.Weather.Web.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Baml.Weather.Web.Infrastructure
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
        {
        }
        public DbSet<Location> Locations { get; set; }
    }
}