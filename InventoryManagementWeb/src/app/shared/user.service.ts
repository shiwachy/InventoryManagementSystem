import { Injectable, OnInit } from '@angular/core';
import { user } from '../login/login.modal';
import { Employees } from '../admin/add-emp/add-emp.model';
import { HttpClient } from '@angular/common/http';
import { employee } from './commonInfo.model';
@Injectable({
  providedIn: 'root'
})
export class UserService{
  constructor(private http:HttpClient){

  }
  currentUser:user= new user();
  empList:any;
  empToUpdate:employee = new employee();


  getEmpList(){
    this.http.get("https://localhost:7244/api/UserInfoAPI/")
    .subscribe((res)=>{
      this.empList = res;
    },(error)=>{
      alert("Failed to load some credentials");
    }
  )
  }

  updateEmp(obj:any){
    this.empToUpdate = obj;
  }

}
