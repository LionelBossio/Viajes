import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Viajes } from '../Interfaces/index';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ViajesService {
  private endpoint: string = environment.endpoint;
  private apiUrl: string = this.endpoint + "/Viajes/";


  constructor(private http: HttpClient) { }

  getViajes(): Observable<Viajes[]> {
    return this.http.get<Viajes[]>(`${this.apiUrl}listaViajes`);
  }
  
}
