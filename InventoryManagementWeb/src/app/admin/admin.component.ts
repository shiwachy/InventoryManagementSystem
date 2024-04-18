import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent {
  constructor(private route:Router,private activeRoute:ActivatedRoute){

  }
  goToEditEmp(compName:string){
    this.route.navigateByUrl(compName); 
  }
}
