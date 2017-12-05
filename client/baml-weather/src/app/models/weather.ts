export class Weather {
    day: string;
    locale: string;
    temperature: number;
    wind: number;
    windDirection: string;
    humidity: number
    shortDescription: string;
    daytime: string;
    precipitation: number; 
}

export class DayWeather {
    weatherDay: string;
    locale: string;
    localeId: number;
    TimedWeatherDetail: TimedWeatherDetail[]
 }

export class TimedWeatherDetail{
    temperature: number;
    wind: number;
    windDirection: number;
    humidity: number
    shortDescription: string;
    dayTime: string;
    precipitation: number; 
    hour: number;
}

