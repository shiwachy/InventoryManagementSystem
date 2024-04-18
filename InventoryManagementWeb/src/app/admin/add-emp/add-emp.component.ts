import { Component } from '@angular/core';
import { AdmindllService } from '../admindll.service';
import { Employees } from './add-emp.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-add-emp',
  templateUrl: './add-emp.component.html',
  styleUrls: ['./add-emp.component.css']
})
export class AddEmpComponent {
    constructor(private adminDllservice:AdmindllService){

    }

    onAddEmpClick(empInfo:NgForm){
     this.adminDllservice.addEmp(empInfo.value);
     empInfo.reset();
    }
}
