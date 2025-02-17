import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

interface Product {
  Id: string;
  Name: string;
  Description: string;
  Price: number;
  Quntity: number;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  public products: Product[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
  }

  title = 'tokenbasedauthenticationdemo.client';
}
