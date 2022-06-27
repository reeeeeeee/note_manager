import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginService } from '../service/login.service';
import { NoteService } from '../service/note.service';

@Component({
  selector: 'app-viewnote',
  templateUrl: './viewnote.component.html',
  styleUrls: ['./viewnote.component.css']
})
export class ViewnoteComponent implements OnInit {
  notelist:any;
  notetypelist:any;
  todaylist:any;
  weeklist:any;
  monthlist:any;
  rangeist:any;
  term = '';
  cp: number = 1;
  submitted = false;
  constructor(private noteservice:NoteService,private loginservice:LoginService,private router:Router) { }

  ngOnInit(): void {
    if(localStorage.getItem('token')!=null)
    {
        this.loginservice.submitted=true;
        this.LoadAllNote();
        this.getNoteType();
        this.getRangeType();
        this.getToday();
        this.getweek();
        this.getmonth();
    }
    else
    {
      this.loginservice.submitted=false;
    }
  }

  viewnoteform:FormGroup=new FormGroup({
    NoteTypeID:new FormControl(),
    Range:new FormControl()
  });

  LoadAllNote()
  {
    this.noteservice.getAllNote().subscribe(data=>{
      this.notelist=data; 
    });
  }
  getNoteType()
  {
    this.noteservice.getNoteType().subscribe(data => {
      this.notetypelist=data;
    });
  }

  getToday()
  {
    this.noteservice.gettoday().subscribe(data => {
      this.todaylist=data;
    });
  }

  getweek()
  {
    this.noteservice.getweek().subscribe(data => {
      this.weeklist=data;
    });
  }

  getmonth()
  {
    this.noteservice.getmonth().subscribe(data => {
      this.monthlist=data;
    });
  }


 getRangeType()
  {
    this.rangeist=[
      {ID:1,range:"Today"},
      {ID:2,range:"This Week"},
      {ID:3,range:"This Month"}
    ]
  }

  onEdit(empid:string)
  {
    //this.router.navigate(['/editemp',empid]);
  }

  onDelete(empid:string)
  {
    //this.empservice.Delete(empid);
  }

  onChange(e:any)
  {
    
  }

  get f(): { [key: string]: AbstractControl } {
    return this.viewnoteform.controls;
  }
  
}
