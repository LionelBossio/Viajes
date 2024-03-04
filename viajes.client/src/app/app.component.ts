import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Viajes } from './Interfaces/index';
import { ViajesService } from './Services/viajes.service';


interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  listaViajes: Viajes[] = [];

  constructor(private _viajeServicio: ViajesService) {

  }

  ListarViajes() {
    this._viajeServicio.getViajes().subscribe({
      next: (viaje) => {
        this.listaViajes = viaje;
      }, error: (e) => { }
    });
  }

  ngOnInit(): void {
    this.ListarViajes();
  }

}
