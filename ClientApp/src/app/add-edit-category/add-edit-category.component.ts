import { Component, OnInit } from '@angular/core';
import { Category } from '../models/Category';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-edit-category',
  templateUrl: './add-edit-category.component.html',
  styleUrls: ['./add-edit-category.component.css']
})
export class AddEditCategoryComponent implements OnInit {

  constructor(private http: HttpClient) { }
  isAdd = false;
  categories: any[] = [];
  selectedCategory: Category = {
    id: 0,
    name: '',
    icon: '',
    minWeight: 0,
    maxWeight: 0
  };

  ngOnInit(): void {
    this.getCategories();
  }

  updateCategory() {
    const updatedCategory = {
      name: this.selectedCategory.name,
      icon: this.selectedCategory.icon,
      minWeight: this.selectedCategory.minWeight,
      maxWeight: this.selectedCategory.maxWeight
    };

    if (this.isAdd) {
      this.isAdd = false;
      this.http.post('https://localhost:44427/api/categories', updatedCategory).subscribe((response) => {
        console.log('Category added successfully', response);
        this.getCategories();
      });
    }
    else {
    const categoryId = this.selectedCategory.id;
    this.http.put(`https://localhost:44427/api/categories/${categoryId}`, updatedCategory).subscribe((response) => {
      console.log('Category updated successfully', response);

      this.getCategories();
    });
  }
  }

  deleteCategory(category: any) {
    const categoryId = category.id;

    this.http.delete(`https://localhost:44427/api/categories/${categoryId}`).subscribe((response) => {
      console.log('Category deleted successfully', response);

      this.getCategories();
    });
  }

  public editCategory(category: Category) {
    this.selectedCategory = { ...category }; // Create a copy to avoid modifying the original
  }

  getCategories() {
    this.http.get<any[]>('https://localhost:44427/api/categories').subscribe((data) => {
      this.categories = data; // Assign the retrieved categories to the 'categories' property
    });
  }

}
