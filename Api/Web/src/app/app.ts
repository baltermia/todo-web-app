import { Component, signal } from '@angular/core';
import {WeatherForecast, WeatherForecastClient} from "./web-api-client";
import { RouterOutlet } from "@angular/router";
import { CommonModule } from "@angular/common";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, CommonModule],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected forecasts: WeatherForecast[] = [];
  protected count: number = 0;

  constructor(private wfClient: WeatherForecastClient) {}
    
    fetch() {
      this.count++;
      this.wfClient.getWeatherForecast().subscribe(result => {
          this.forecasts = result;
      });
    }
}
