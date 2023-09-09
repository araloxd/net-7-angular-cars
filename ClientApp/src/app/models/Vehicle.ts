import { Category } from "./Category";
import { Manufacturer } from "./Manufacturer";

export interface Vehicle {
    id?: number;
    ownerName?: string;
    manufacturer?: Manufacturer;
    manufacturerId?: number;
    yearOfManufacture: number;
    weight : number;
    category?: Category;
  }
