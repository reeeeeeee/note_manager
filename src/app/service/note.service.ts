import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class NoteService {
  readonly APIUrl="http://localhost:58483/api/Note";
  constructor(private toastr:ToastrService,private http:HttpClient,private router:Router) { }

  getNoteType() : Observable<any[]>{
    return this.http.get<any>(this.APIUrl);
  }

  getAllNote() : Observable<any[]>{
    return this.http.get<any>(this.APIUrl+"/LoadAllNote");
  }

  gettoday() : Observable<any[]>{
    return this.http.get<any>(this.APIUrl+"/LoadTodayRemTodo");
  }

  getweek() : Observable<any[]>{
    return this.http.get<any>(this.APIUrl+"/LoadWeekRemTodo");
  }

  getmonth() : Observable<any[]>{
    return this.http.get<any>(this.APIUrl+"/LoadMonthRemTodo");
  }

  insertNote(emp :any)
  {
    this.http.post<any>(this.APIUrl,emp).subscribe({
      next:data =>{
        if(data==1)
        {
          this.toastr.success('Note created successfully.');
        }
        else
        {
          this.toastr.success('Note creation failed.');
        }
      },
      error:error=>{
        this.toastr.error('Unable to create note .');
      }
    })
  }
}
