import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from 'src/app/service/login.service';
import { SignupService } from 'src/app/service/signup.service';
import {ConfirmedValidator} from '../../confirmed-validator.model';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  submitted = false;
  constructor(private router:Router,private loginservice:LoginService,private signupservice:SignupService) { }

  ngOnInit(): void {
    this.loginservice.submitted=false;
  }

  signupform:FormGroup=new FormGroup({
    name:new FormControl('',Validators.required),
    email:new FormControl('',[Validators.required,Validators.email]),
    dateofbirth:new FormControl('',Validators.required),
    password:new FormControl('',Validators.required),
    ConPass:new FormControl('',[Validators.required])
  },
  { 
    validators: [ConfirmedValidator.match('password', 'ConPass')]
  });


  get f(): { [key: string]: AbstractControl } {
    return this.signupform.controls;
  }
  
  onSubmit() : void
  {
    this.submitted=true;
    if(this.signupform.valid)
      this.signupservice.signup(this.signupform.value);
  }

}
