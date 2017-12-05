import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/throw';

import { DayWeather, TimedWeatherDetail } from '../models/weather';
import { Observable } from 'rxjs/Observable';
import { Console } from '@angular/core/src/console';
                      
@Injectable()
export class WeatherService {

  constructor(private http: Http) { }
  private weatherServiceUrl = '/api/weather/getbylocation/Birming';
  private serviceBase = 'http://localhost:63494';

  getWeatherForecast(): Promise<Array<DayWeather>>{
    return this.http
    .get(this.serviceBase + this.weatherServiceUrl)
    .toPromise()
    .then((response) => {
      var result = response.json()
      return result as  DayWeather[];
    })
    .catch(this.errorHandler);
  }

  private errorHandler(error: any): Promise<any>{
    console.error('Error thrown in service', error);
    return Promise.reject(error.message || error);
  }
}
