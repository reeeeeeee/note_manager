import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LoginComponent } from './login/login.component';
import { LoginService } from './service/login.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: [
    './app.component.css'
  ]
})

export class AppComponent {
  ngOnInit(): void {
 
  }

  Signout()
  {
    localStorage.removeItem('token');
    this.loginservice.submitted=false;
    this.router.navigate(['/login']);
  }

  constructor(private http:HttpClient,private router:Router,public login:LoginComponent,public loginservice:LoginService){}

  title = 'Note Management System';
}

