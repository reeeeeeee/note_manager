import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class SignupService {
  submitted = false;

  private readonly apiURL="http://localhost:58483/api/Registration";

  constructor(private http: HttpClient,private router:Router,private toastr:ToastrService) { }

  signup(user:any):any
  {
    this.http.post<any>(this.apiURL,user).subscribe({
      next:data=>{
          if(data==1)
          {
            this.toastr.success('Registration Successfully completed.');
            this.submitted=false;
            this.router.navigate(['/login']);
          }
          else
          {
            this.toastr.error('Registration Failed.');
          }
      },
      error:error=>{

      }
    });
  }
}

