import { Component, OnInit } from '@angular/core';
import { VehicleService } from '../services/vehicle.service';
import { Vehicle } from '../models/Vehicle';

@Component({
  selector: 'app-list-vehicles',
  templateUrl: './list-vehicles.component.html',
  styleUrls: ['./list-vehicles.component.css']
})
export class ListVehiclesComponent implements OnInit {
  public vehicles?: Vehicle[];

  constructor(private vehicleService: VehicleService) { }

  ngOnInit() {
    this.vehicleService.getAllVehicles().subscribe((data: any) => {
      this.vehicles = data;
    });
  }
}
