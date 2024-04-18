import { Component } from '@angular/core';
import { UserService } from '../shared/user.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent {
  constructor(private userService:UserService, private route:Router){

  }
  role:string=this.userService.currentUser.role;

  logoutSure(){
    let flag = confirm("Are you sure");
    console.log(flag);
    if(flag){
      this.route.navigateByUrl('login');
    }
  }

}
