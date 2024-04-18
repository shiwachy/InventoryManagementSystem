import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { stock } from './stock.model';

@Injectable({
  providedIn: 'root'
})
export class StockService {

  constructor(private http:HttpClient) { }

  stockList:any;
  stockToUpdate:stock = new stock();
  isUpdatable:boolean = false;
  getStockToUpdate(obj:stock){
    this.stockToUpdate = obj;
    this.isUpdatable = true;
  }

  getStock(){
    this.http.get("https://localhost:7244/api/StockAPI").subscribe(
      (res)=>{
        this.stockList = res;
      },(error)=>{
        alert("failed to load Credentials");
      }
    )
  }

  postStock(obj:stock){
    console.log(obj);
    this.http.post("https://localhost:7244/api/StockAPI",obj).subscribe(
      (res)=>{
        alert("Stock Added successfully");
      },(error)=>{
        alert("Unable to add stock")
      }
    )
  }

  putStock(id:string,obj:stock){
    this.http.put(`https://localhost:7244/api/StockAPI/${id}`,obj)
    .subscribe(
      (res)=>{

      },()=>{
        alert("store Updated Successfully")
      },
      ()=>{
        alert("Unable to Update Store")
      }
    )
  }

}
