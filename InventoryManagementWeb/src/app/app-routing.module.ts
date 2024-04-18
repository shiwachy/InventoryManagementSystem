import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEmpComponent } from './admin/add-emp/add-emp.component';
import { EditEmpComponent } from './admin/edit-emp/edit-emp.component';
import { WareHouseComponent } from './ware-house/ware-house.component';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AdminComponent } from './admin/admin.component';
import { AddItemComponent } from './ware-house/add-item/add-item.component';
import { StockComponent } from './ware-house/stock/stock.component';
import { StoresComponent } from './ware-house/stores/stores.component';
import { WelcomePageComponent } from './welcome-page/welcome-page.component';

const routes: Routes = [
  {path:"",component:LoginComponent},
  {path:"login",component:LoginComponent},
  {path:"home",component:HomeComponent,children:[
    {path:"",component:WelcomePageComponent},
    {path:"admin",component:AdminComponent,children:[
      {path:"",component:EditEmpComponent},
      {path:"add-emp",component:AddEmpComponent},
      {path:"edit-emp",component:EditEmpComponent},
    ]},
    {path:"warehouse",component:WareHouseComponent,children:[
      {path:"",component:AddItemComponent},
      {path:"add-item",component:AddItemComponent},
      {path:"stock",component:StockComponent},
      {path:"stores",component:StoresComponent}
    ]}
  ]}
  
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
