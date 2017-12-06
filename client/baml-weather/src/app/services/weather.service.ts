import { Injectable } from '@angular/core';
import { Headers, Http, Response } from '@angular/http';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/throw';

import { DayWeather, TimedWeatherDetail, WeatherLocation } from '../models/weather';
import { Observable } from 'rxjs/Observable';
import { Console } from '@angular/core/src/console';
                      
@Injectable()
export class WeatherService {

  constructor(private http: Http) { }
  private weatherServiceUrl = '/api/weather/getbylocation/Birming';
  private locationSearchServiceUrl = '/api/weather/searchlocation/';
  private serviceBase = 'http://localhost:63494';

  search(term: string):Observable<WeatherLocation[]>{
    return this.http
    .get('${this.serviceBase}${this.locationSearchServiceUrl}${term}')
    .map((r: Response) => r.json().data as WeatherLocation[])
    .catch((error: any) => {
        console.error('An errored occured whilst searching on location', error);
        return Observable.throw(error.message || error);
    });
  }

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
