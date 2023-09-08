import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common'
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ListVehiclesComponent } from './list-vehicles/list-vehicles.component';
import { AddVehicleComponent } from './add-vehicle/add-vehicle.component';
import { AddUserComponent } from './add-user/add-user.component';
import { AddEditCategoryComponent } from './add-edit-category/add-edit-category.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    ListVehiclesComponent,
    AddVehicleComponent,
    AddEditCategoryComponent
  ],
  imports: [
    CommonModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'add-user', component: AddUserComponent},
      { path: 'list-vehicles', component: ListVehiclesComponent },
      { path: 'add-vehicle', component: AddVehicleComponent},
      {path: 'add-edit-category', component: AddEditCategoryComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
