import { Component, OnInit } from '@angular/core';
import { Weather } from '../models/weather';
// import { MatSlideToggleChange } from '@angular/material/slide-toggle';
@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']

})
export class WeatherComponent implements OnInit {

  fiveDayReportArray: Weather[] = [];
  selectedTabIndex: number = 0;
  tempUnitIsCelsius: boolean = true;
  tempUnitText: string = "Celsius" ;
  tempUnitSuffix = "°C"
  date = "03 Decmber 2017"
  ctx = {day: this.date}
  days = [{day: "01 Dec 2017"}, {day: "02 Dec 2017"}, {day: "03 Dec 2017"}, {day: "04 Dec 2017"}, {day: "05 Dec 2017"} ]
  currentDayWeather: Weather;
  lastUpdate: string;

  onTabChange(event) {
      if(event == undefined) return;
      if(event.index == undefined) return;
      this.setCurrentDayWeatherEntity(event.index)
  }

  onSlideChange(event){
    if(event == undefined) return;
    if(event.checked)
    {
        this.tempUnitIsCelsius = true;
        this.tempUnitText = "Celcius";
        this.tempUnitSuffix = "°C"
    }
    else
    {
        this.tempUnitIsCelsius = false;
        this.tempUnitText = "Fahrenheit";
        this.tempUnitSuffix = "°F"
    }
  }

  
  setCurrentDayWeatherEntity(index: number): void{
    this.currentDayWeather = this.fiveDayReportArray[index];
  }

  constructor() {
  }

  ngOnInit() {
    // day: string;
    // locale: string;
    // temprature: number;
    // wind: number;
    // humidity: number
    // shordDescription: string;
    // daytime: string;
    this.fiveDayReportArray = [
      {day: "03 Dec 2017", locale:"Ashtead, Surrey", temperature: 5, wind: 12, windDirection: "NE", humidity: 70, precipitation: 58, shortDescription:"Mostly Sunny", daytime:"Sat2, 15:45"},
      {day: "04 Dec 2017", locale:"Ashtead, Surrey", temperature: 4, wind: 8, windDirection: "NE", humidity: 80, precipitation: 73, shortDescription:"Cloudy and Cold", daytime:"Sat3, 15:45"},
      {day: "05 Dec 2017", locale:"Ashtead, Surrey", temperature: 6, wind: 3, windDirection: "NE", humidity: 90, precipitation: 83,  shortDescription:"Blazing HOt", daytime:"Sat4, 15:45"},
      {day: "06 Dec 2017", locale:"Ashtead, Surrey", temperature: -3, wind: 19, windDirection: "NE", humidity: 60, precipitation: 24, shortDescription:"Cloud and Sunny", daytime:"Sat5, 15:45"},
      {day: "07 Dec 2017", locale:"Ashtead, Surrey", temperature: 9, wind: 4, windDirection: "NE", humidity: 40, precipitation: 18, shortDescription:"Rainy", daytime:"Sat6, 15:45"},
    ]

    // well be set when service call is made
    this.lastUpdate = "03 December, 20:35";
    this.setCurrentDayWeatherEntity(0);
  }

}


