import { Component,OnInit } from '@angular/core';
import { WarehouseService } from '../services/warehouse.service';
import { EditButtonRendererComponent } from 'src/app/shared/editButtonRenderer.component';
import { ColDef } from 'ag-grid-community'; 
import { AddItemService } from './add-item.service';
import { item } from './item.modal';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-add-item',
  templateUrl: './add-item.component.html',
  styleUrls: ['./add-item.component.css']
})
export class AddItemComponent implements OnInit{

  constructor(private wareHouse:WarehouseService,
      public addItemService:AddItemService
  ){

  }


  ngOnInit():void{
     this.getItemList();
  }

  //rowData = this.addItemService.itemList;

  empListColDefs:ColDef []= [
   { field: "itemId", headerName: "Item ID", filter:'true'},
   { field: "itemCode", headerName: "Item Code", filter:'true'},
   { field: "itemName",headerName:"Item Name", filter:'true'},
   { field: "brandName",headerName:"Brand Name", filter:'true'},
   { field: "unitOfMeasurement", headerName: "Unit of Measure", filter:'true'},
   { field: "purchaseRate", headerName: "Purchase Rate", filter:'true'},
   { field: "salesRate", headerName: "Sales Rate", filter:'true'},
   { field: "isActive", headerName: "Is Active", filter:'true'},
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
  
  getItemList(){
    this.addItemService.getItems();
  }

  onClickAddItem(newItem:NgForm){
    this.addItemService.postItem(newItem.value);
    this.wareHouse.closeModal("addItemModal");
  }


  onUpdateClick(){
    this.addItemService.putItem(this.addItemService.itemToUpdate.itemId,this.addItemService.itemToUpdate); 
  }

  onClickOpenModal(modelId:string){
    this.wareHouse.openModal(modelId);
  }

  onClickCloseModal(modelId:string){
    this.wareHouse.closeModal(modelId);
    this.addItemService.isUpdatable = false;
  }
  

}
