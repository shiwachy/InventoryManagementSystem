import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { AddEmpComponent } from './admin/add-emp/add-emp.component';
import { EditEmpComponent } from './admin/edit-emp/edit-emp.component';
import { AgGridAngular } from 'ag-grid-angular';
import { AddItemComponent } from './ware-house/add-item/add-item.component';
import { AddModelComponent } from './add-model/add-model.component';
import { RouterModule, Routes } from '@angular/router';
import { WareHouseComponent } from './ware-house/ware-house.component';
import { StockComponent } from './ware-house/stock/stock.component';
import { StoresComponent } from './ware-house/stores/stores.component';
import { HomeComponent } from './home/home.component';
import { SideNavComponent } from './side-nav/side-nav.component';
import { AdminComponent } from './admin/admin.component';
import { WelcomePageComponent } from './welcome-page/welcome-page.component';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    AddEmpComponent,
    EditEmpComponent,
    AddItemComponent,
    AddModelComponent,
    WareHouseComponent,
    StockComponent,
    StoresComponent,
    HomeComponent,
    SideNavComponent,
    AdminComponent,
    WelcomePageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AgGridAngular,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
