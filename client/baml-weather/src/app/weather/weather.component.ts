import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-weather',
  templateUrl: './weather.component.html',
  styleUrls: ['./weather.component.css']

})
export class WeatherComponent implements OnInit {

  date = "03 Decmber 2017"
  ctx = {day: this.date}
  days = [{day: "01 Dec 2017"}, {day: "02 Dec 2017"}, {day: "03 Dec 2017"}, {day: "04 Dec 2017"}, {day: "05 Dec 2017"} ]
  constructor() {
    
   }

  ngOnInit() {
  }

}


