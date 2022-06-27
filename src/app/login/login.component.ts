import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoginService } from '../service/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  submitted = false;
  constructor(private loginservice:LoginService,private router:Router,private toastr:ToastrService) { }

  ngOnInit(): void {

  }

  get f(): { [key: string]: AbstractControl } {
    return this.loginform.controls;
  }
  
  loginform:FormGroup=new FormGroup({
    email:new FormControl('',[Validators.required,Validators.email]),
    password:new FormControl('',Validators.required)
  });

  onSubmit()
  {
    this.submitted=true;
      this.loginservice.Login(this.loginform.value);
  }
}
