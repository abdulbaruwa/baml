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
  date = "03 Decmber 2017"
  ctx = {day: this.date}
  days = [{day: "01 Dec 2017"}, {day: "02 Dec 2017"}, {day: "03 Dec 2017"}, {day: "04 Dec 2017"}, {day: "05 Dec 2017"} ]


  onSlideChange(event){
    if(event == undefined) return;
    if(event.checked)
    {
        this.tempUnitIsCelsius = true;
        this.tempUnitText = "Celcius";
    }
    else
    {
        this.tempUnitIsCelsius = false;
        this.tempUnitText = "Fahrenheit";
    }
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
      {day: "03 Dec 2017", locale:"Ashtead, Surrey", temperature: 5, wind: 12, windDirection: "NE", humidity: 80, shortDescription:"Mostly Sunny", daytime:"Sat2, 15:45"},
      {day: "04 Dec 2017", locale:"Ashtead, Surrey", temperature: 4, wind: 8, windDirection: "NE", humidity: 80, shortDescription:"Mostly Sunny", daytime:"Sat3, 15:45"},
      {day: "05 Dec 2017", locale:"Ashtead, Surrey", temperature: 6, wind: 3, windDirection: "NE", humidity: 80, shortDescription:"Mostly Sunny", daytime:"Sat4, 15:45"},
      {day: "06 Dec 2017", locale:"Ashtead, Surrey", temperature: -3, wind: 19, windDirection: "NE", humidity: 80, shortDescription:"Mostly Sunny", daytime:"Sat5, 15:45"},
      {day: "07 Dec 2017", locale:"Ashtead, Surrey", temperature: 9, wind: 4, windDirection: "NE", humidity: 80, shortDescription:"Mostly Sunny", daytime:"Sat6, 15:45"},
    ]
  }

}


