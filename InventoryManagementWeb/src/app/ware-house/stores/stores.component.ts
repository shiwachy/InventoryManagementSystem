import { Component } from '@angular/core';
import { EditButtonRendererComponent } from 'src/app/shared/editButtonRenderer.component';
import { WarehouseService } from '../services/warehouse.service';
import { ColDef } from 'ag-grid-community'; 
import { StoresService } from './stores.service';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-stores',
  templateUrl: './stores.component.html',
  styleUrls: ['./stores.component.css']
})
export class StoresComponent {
  constructor(private wareHouse:WarehouseService,
    public storesService:StoresService
  ){

  }
 
  ngOnInit():void{
    this.getStoreList();
  }


  empListColDefs:ColDef []= [
   { field: "storeId", headerName: "STORE ID", filter:'true'},
   { field: "storeName",headerName:"STORE NAME", filter:'true'},
   { field: "isActive",headerName:"IS ACTIVE", filter:'true'},
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

  getStoreList(){
    this.storesService.getStore();
  }
  
  onClickAddStore(storeInfo:NgForm){
    this.storesService.postStore(storeInfo.value);
    this.onClickCloseModal("createStoreModal");
  }

  onClickUpdateStore(){
    this.storesService.putStore(this.storesService.storeToUpdate.storeId,this.storesService.storeToUpdate);
    this.storesService.isUpdatable = false;
    this.onClickCloseModal("createStoreModal");
  }
  onClickOpenModal(modelId:string){
    this.wareHouse.openModal(modelId);
  }

  onClickCloseModal(modelId:string){
    this.wareHouse.closeModal(modelId);
  }
  
}
