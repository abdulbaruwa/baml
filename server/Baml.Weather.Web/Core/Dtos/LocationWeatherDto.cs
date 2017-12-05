using System;
using System.Reflection.PortableExecutable;

namespace Baml.Weather.Web.Core.Dtos
{
    public class ResponseDto
    {
        public WeatherDto[] WeatherDtos { get; set; }
    }

    public class WeatherDto
    {
       public string WeatherDay { get; set; }
        public string Locale { get; set; }
        public int LocaleId { get; set; }

        public TimedWeatherDetail[] TimedWeatherDetail { get; set; }
    }

    public class TimedWeatherDetail
    {

        public string Day { get; set; }
        public double Temperature { get; set; }
        public double Wind { get; set; }
        public double WindDirection { get; set; }
        public int Humidity { get; set; }
        public string ShortDescription { get; set; }
        public DateTimeOffset DayTime { get; set; }
        public double Precipitation { get; set; }
        public int Hour => DayTime.Hour;

    }
}