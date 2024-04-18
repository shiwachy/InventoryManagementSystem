import { Injectable } from '@angular/core';
import { user } from '../login/login.modal';
import { HttpClient } from '@angular/common/http';
import { employee } from './admin.model';

@Injectable({
  providedIn: 'root'
})
export class AdmindllService {

  constructor(private http:HttpClient) { }

  addEmp(empInfo:user){
    this.http.post("https://localhost:7244/api/UserInfoAPI",empInfo).subscribe((res)=>{
      console.log(JSON.stringify(res));
    })
  }

  updateEmp(emp:employee){
    this.http.put(`https://localhost:7244/api/UserInfoAPI/${emp.userId}`,emp)
    .subscribe((res)=>{
      alert(res);
    },()=>{
     
    }
  )
  }
  
}
