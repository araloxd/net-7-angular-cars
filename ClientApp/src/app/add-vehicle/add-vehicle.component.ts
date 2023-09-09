import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { VehicleService } from '../services/vehicle.service';
import { Manufacturer } from '../models/Manufacturer';
import { Vehicle } from '../models/Vehicle';

@Component({
  selector: 'app-add-vehicle',
  templateUrl: './add-vehicle.component.html',
  styleUrls: ['./add-vehicle.component.css']
})
export class AddVehicleComponent implements OnInit {
  vehicleForm: FormGroup = new FormGroup({});
  manufacturers: Manufacturer[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private vehicleService: VehicleService
  ) {}

  ngOnInit(): void {
    this.vehicleForm = this.formBuilder.group({
      ownerName: ['', Validators.required],
      manufacturer: ['', Validators.required],
      yearOfManufacture: ['', Validators.required],
      weight: ['', [Validators.required, Validators.min(0.01)]]
    });

    this.vehicleService.getManufacturers().subscribe((data) => {
      this.manufacturers = data;
    });
  }

  onSubmit(): void {
    if (this.vehicleForm.valid) {
      const vehicleData = this.vehicleForm.value;
      const selectedManufacturer = this.manufacturers.find(x => x.name === vehicleData.manufacturer);
      const newVehicle: Vehicle = {
        ownerName: vehicleData.ownerName,
        manufacturer: selectedManufacturer,
        //manufacturerId: selectedManufacturer?.id,
        yearOfManufacture: vehicleData.yearOfManufacture,
        weight: vehicleData.weight
      };


      this.vehicleService.addVehicle(newVehicle).subscribe(
        (response: any) => {
          console.log('Vehicle added successfully:', response);
        },
        (error: any) => {
          console.error('Error adding vehicle:', error);
        }
      );
    }
  }


}
