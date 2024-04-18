import { Injectable, OnInit } from '@angular/core';
declare var window:any;
@Injectable({
  providedIn: 'root'
})
export class WarehouseService implements OnInit {

  constructor() { }

  formModal:any;
  ngOnInit():void{
   
  }

  openModal(modelId:string){
    this.formModal = new window.bootstrap.Modal(
      document.getElementById(modelId)
    )  
    this.formModal.show();
  }

  closeModal(modelId:string){
    this.formModal.hide();
  }
}
