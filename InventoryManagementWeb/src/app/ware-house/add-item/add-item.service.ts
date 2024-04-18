import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { item } from './item.modal';

@Injectable({
  providedIn: 'root'
})
export class AddItemService {

  constructor(private http:HttpClient) { }

  itemList:any;
  itemToUpdate:item = new item();
  isUpdatable:boolean = false;

  getItemToUpdate(obj:item){
    this.itemToUpdate = obj;
    this.isUpdatable = true;
  }

  getItems(){
    this.http.get("https://localhost:7244/api/ItemsAPI")
    .subscribe(
      (res)=>{
        this.itemList = res;
      },
      (error)=>{
        alert(error+"Failed to Load Credentials");
      }
    )
  }

  postItem(newItem:any){
    this.http.post("https://localhost:7244/api/ItemsAPI",newItem)
    .subscribe(()=>{
      alert("Item Added Successfully");
    })
  }

  putItem(id:string,obj:item){
    this.http.put(`https://localhost:7244/api/ItemsAPI/${id}`,obj)
    .subscribe(()=>{
    },(msg)=>{
      alert("Item Updated Successfully");
    },()=>{
      alert("Unable to Update Item")
    }
  )
  }
}
