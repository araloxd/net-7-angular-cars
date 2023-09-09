import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Vehicle } from '../models/Vehicle';
import { Observable } from 'rxjs';
import { Manufacturer } from '../models/Manufacturer';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  private apiUrl = 'https://localhost:44427/api'; 

  constructor(private http: HttpClient) { }

  getAllVehicles() {
    return this.http.get(`${this.apiUrl}/vehicles`);
  }

  addVehicle(newVehicle: Vehicle){
    return this.http.post(`${this.apiUrl}/vehicles`, newVehicle);
  }

  getManufacturers(): Observable<Manufacturer[]> {
    return this.http.get<Manufacturer[]>(`${this.apiUrl}/manufacturers`);
  }
}
