import { Category } from "./Category";
import { Manufacturer } from "./Manufacturer";

export interface Vehicle {
    id: number;
    ownerName?: string;
    manufacturer?: Manufacturer;
    yearOfManufacture: number;
    weight : number;
    category?: Category;
  }
  