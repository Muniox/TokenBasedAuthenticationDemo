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
    //this.getForecasts();
    this.getProducts();
  }

  getProducts() {
    this.http.get<Product[]>('/products').subscribe(
      {
        next: (result) => {
          this.products = result;
          console.log(result);
        }
      }
    )
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'tokenbasedauthenticationdemo.client';
}
