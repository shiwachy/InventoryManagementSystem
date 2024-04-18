import { Component } from '@angular/core';
import { WarehouseService } from '../services/warehouse.service';
import { EditButtonRendererComponent } from 'src/app/shared/editButtonRenderer.component';
import { ColDef } from 'ag-grid-community'; 
import { StockService } from './stock.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-stock',
  templateUrl: './stock.component.html',
  styleUrls: ['./stock.component.css']
})
export class StockComponent {
  constructor(private wareHouse:WarehouseService,
      public stockService:StockService
    ){
  }
 
  ngOnInit():void{
     this.getStockList();
  }


  empListColDefs:ColDef []= [
   { field: "stockId", headerName: "STOCK ID", filter:'true'},
   { field: "storeId",headerName:"STORE ID", filter:'true'},
   { field: "itemId",headerName:"ITEM ID", filter:'true'},
   { field: "quantity",headerName:"QUANTITY", filter:'true'},
   { field: "expiaryDate",headerName:"Expiry Date", filter:'true'},
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
  
  getStockList(){
    this.stockService.getStock();
  }

  onClickAddStock(obj:NgForm){
    this.stockService.postStock(obj.value);
    this.onClickCloseModal("createStockModal");
  }

  onUpdateClick(){
    this.stockService.putStock(this.stockService.stockToUpdate.stockId,this.stockService.stockToUpdate);
    this.stockService.isUpdatable = false;
    this.onClickCloseModal("createStockModal");
  }
  onClickOpenModal(modelId:string){
    this.wareHouse.openModal(modelId);
  }

  onClickCloseModal(modelId:string){
    this.wareHouse.closeModal(modelId);
  }
  
}
