import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  private apiUrl = 'https://localhost:44427/api/vehicles'; 

  constructor(private http: HttpClient) { }

  getAllVehicles() {
    return this.http.get(this.apiUrl);
  }
}
