import { Component, OnInit, ViewChild } from '@angular/core';
import { user } from './login.modal';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../shared/user.service';
import { HttpClient } from '@angular/common/http';
import { Employees } from '../admin/add-emp/add-emp.model';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  constructor(private route:Router,private activeRoute:ActivatedRoute,
    private userService:UserService,
    private http:HttpClient
  ){

  }

  currentUser!:user;
  validUser:any;
  
    ngOnInit(): void {
      
    }

    
    verityUser(){
      if(this.validUser!=null){
        if(this.currentUser.userName==this.validUser.userName && this.currentUser.password==this.validUser.password){
          this.userService.currentUser.role = this.validUser.role;
          this.load_dbData();
          this.route.navigateByUrl('home'); 
        }
      }else{
        alert("Incorrect Id or password");
      }
    }

    getValidUser(userDetail:NgForm){
        this.currentUser = userDetail.value;
        this.http.get("https://localhost:7244/api/UserInfoAPI/"+userDetail.value.userName)
        .subscribe((res)=>{
            this.validUser = res;
            userDetail.reset();
        },
        (error)=>{
          alert("User not found");
        },
        ()=>{
          this.verityUser();
        }
      )
      
    }

    load_dbData(){
      this.userService.getEmpList();
    }
    
}
