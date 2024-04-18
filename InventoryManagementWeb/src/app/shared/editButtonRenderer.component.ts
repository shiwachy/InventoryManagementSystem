import { Component } from '@angular/core';
import { AgRendererComponent } from 'ag-grid-angular';
import { ICellRendererParams } from 'ag-grid-community';
import { WarehouseService } from '../ware-house/services/warehouse.service';
import { UserService } from './user.service';
import { AddItemService } from '../ware-house/add-item/add-item.service';
import { StoresService } from '../ware-house/stores/stores.service';
import { StockService } from '../ware-house/stock/stock.service';

@Component({
  selector: 'edit-button-renderer',
  template: `<button (click)="editClicked()" class="btn btn-danger">Edit</button>`,
})
export class EditButtonRendererComponent implements AgRendererComponent {

  constructor(private warehouse:WarehouseService, 
    private userService:UserService,
    private addItemService:AddItemService,
    private storeService:StoresService,
    private stockService:StockService
  ) {}

  rowData:any;
  agInit(params: ICellRendererParams): void {
    this.rowData = params;
  }

  refresh(params: ICellRendererParams): boolean {
    return false;
  }

  editClicked() {
    console.log('Edit clicked!', this.rowData.data);    
    if(this.rowData.data.hasOwnProperty("userId")){
      this.userService.updateEmp(this.rowData.data);
      this.onClickOpenModal("editEmpModal");
    }else if(this.rowData.data.hasOwnProperty("itemId") && this.rowData.data.hasOwnProperty("itemCode")){
      this.addItemService.getItemToUpdate(this.rowData.data);
      this.onClickOpenModal("addItemModal");
    }else if(this.rowData.data.hasOwnProperty("storeId") && this.rowData.data.hasOwnProperty("storeName")){
      this.storeService.getStoreToUpdate(this.rowData.data);
      this.onClickOpenModal("createStoreModal");
    }else if(this.rowData.data.hasOwnProperty("itemId") && this.rowData.data.hasOwnProperty("stockId")){
      this.stockService.getStockToUpdate(this.rowData.data);
      this.onClickOpenModal("createStockModal");
    }
    
  }
  onClickOpenModal(modelId:string){
    this.warehouse.openModal(modelId);
  }

  
}
