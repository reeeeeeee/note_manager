import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})

export class LoginService {
  submitted = false;

  private readonly apiURL="http://localhost:58483/api/Login";

  constructor(private http:HttpClient,private router:Router,private toastr:ToastrService) { }

  Login(user:any):any
  {
    //return this.http.post<any>(this.apiURL,user);
    this.http.post<any>(this.apiURL,user).subscribe({
      next:data=>{
          if(data==0)
          {
            this.toastr.error('Invalid username or password.','Authentication Failed');
            this.submitted=false;
          }
          else
          {
            localStorage.setItem('token',data);
            localStorage.setItem('UserID',user.email);
            this.submitted=true;
            this.router.navigate(['/viewnote']);
          }
      },
      error:error=>{

      }
    });
  }
}

