import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { store } from './store.model';

@Injectable({
  providedIn: 'root'
})
export class StoresService {

  constructor(
    private http:HttpClient
  ) { }

  storeList:any;
  storeToUpdate:store = new store();
  isUpdatable:boolean = false;

  getStoreToUpdate(obj:store){
    this.storeToUpdate = obj;
    this.isUpdatable = true;
  }
  getStore(){
    this.http.get("https://localhost:7244/api/StoreAPI").subscribe(
      (res)=>{
        this.storeList = res;
      },
      (error)=>{
        alert("unable to load credentials");
      }
    )
  }

  postStore(obj:store){
    this.http.post("https://localhost:7244/api/StoreAPI",obj).subscribe(
      (res)=>{
        console.log(res);
      },
      (msg)=>{
        alert("Store Added Successfully");
      }
    )
  }

  putStore(id:string,obj:store){
    this.http.put(`https://localhost:7244/api/StoreAPI/${id}`,obj)
    .subscribe(
      ()=>{
        
      },()=>{
        alert("Store Updated Successfully");
      }
    )
  }
}
