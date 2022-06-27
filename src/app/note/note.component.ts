import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Toast, ToastrService } from 'ngx-toastr';
import { LoginService } from '../service/login.service';
import { NoteService } from '../service/note.service';

@Component({
  selector: 'app-note',
  templateUrl: './note.component.html',
  styleUrls: ['./note.component.css']
})
export class NoteComponent implements OnInit {
  public edited=false;
  public complete=false;

  submitted = false;
  public notlist:any;
  constructor(private router:Router,private loginservice:LoginService,private noteservice:NoteService,private toastr:ToastrService) { }

  get f(): { [key: string]: AbstractControl } {
    return this.noteform.controls;
  }
  
  onView()
  {
    this.router.navigate(['/viewnote']);
  }

  getNoteType()
  {
    this.noteservice.getNoteType().subscribe(data => {
      this.notlist=data;
    });
  }

  noteform:FormGroup=new FormGroup({
    NoteTypeID:new FormControl(),
    NoteText:new FormControl('',[Validators.required,Validators.maxLength(100)]),
    DateTime:new FormControl(),
    InoperationID:new FormControl()
  });
  
  ngOnInit(): void {
    if(localStorage.getItem('token')!=null)
    {
        this.loginservice.submitted=true;
        this.getNoteType();
    }
    else
    {
      this.loginservice.submitted=false;
    }
  }

  onSubmit() : void
  {
    this.submitted=true;
    if(this.noteform.value.NoteTypeID==null || this.noteform.value.NoteText=='')
    {
      this.toastr.error('Please select a note type and enter note text');
    }
    else if((this.noteform.value.NoteTypeID==2 || this.noteform.value.NoteTypeID==3) && this.noteform.value.DateTime==null)
    {
      this.toastr.error('Please select a Date Time');
    }
    else
    {
      this.noteservice.insertNote(this.noteform.value);
    }

  }

  onChange(e:any)
  {
    if(e.target.value==1)
    {
      this.edited=false;
      this.complete=false;
    }
    else if(e.target.value==2)
    {
      this.complete=false;
      this.edited=true;
    }
    else if(e.target.value==3)
    {
      this.edited=true;
      this.complete=true;
    }
    else if(e.target.value==4)
    {
      this.edited=false;
      this.complete=false;
    }
  }
}
