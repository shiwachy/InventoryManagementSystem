import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { AgGridAngular } from 'ag-grid-angular'; // AG Grid Component
import { ColDef } from 'ag-grid-community'; 
import { EditButtonRendererComponent } from '../../shared/editButtonRenderer.component';
import { UserService } from 'src/app/shared/user.service';
import { WarehouseService } from 'src/app/ware-house/services/warehouse.service';
import { user } from 'src/app/login/login.modal';
import { employee } from '../admin.model';
import { AdmindllService } from '../admindll.service';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-edit-emp',
  templateUrl: './edit-emp.component.html',
  styleUrls: ['./edit-emp.component.css']
})
export class EditEmpComponent implements OnInit{
  constructor(public userService:UserService, 
    private wareHouse:WarehouseService,
    private adminDllService:AdmindllService
  ){
    
  }
  @ViewChild('newComp') newComp!:ElementRef;

  ngOnInit(): void {
    this.getEmpList();
  }
 
  rowData = this.userService.empList;
  empListColDefs:ColDef []= [
   { field: "userId", headerName: "USER ID", filter:'true'},
   { field: "fullName", headerName: "FULL NAME", filter:'true'},
   { field: "userName",headerName:"USER NAME", filter:'true'},
   { field: "password",headerName:"PASSWORD", filter:'true'},
   {field:"isActive",headerName:"IS ACTIVE"},
   {
    headerName: "EDIT",
    // cellRendererFramework: EditButtonRendererComponent,
    cellRenderer:EditButtonRendererComponent,
    width: 100
  }
   
  ]
  defaultColdefs = {
    flex:1,
    minWidth:100
  }
  
  getEmpList(){
    this.userService.getEmpList();
  }

  onUpdateEmpClick(emp:NgForm){
    this.adminDllService.updateEmp(emp.value);
    this.wareHouse.closeModal("editEmpModal");
  }

  closeModalClick(){
    this.wareHouse.closeModal("editEmpModal");
  }
  
 
}
