import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth/auth.guard';
import { LoginComponent } from './login/login.component';
import { NoteComponent } from './note/note.component';
import { PaageNotFoundComponent } from './paage-not-found/paage-not-found.component';
import { SignupComponent } from './signup/signup/signup.component';
import { ViewnoteComponent } from './viewnote/viewnote.component';

const routes: Routes = [
  {path:'',redirectTo:'login',pathMatch:'full'},
  {path:'login',component:LoginComponent},
  {path:'signup',component:SignupComponent},
  {path:'note',component:NoteComponent},
  {path:'viewnote',component:ViewnoteComponent},
  {path:"**",component:PaageNotFoundComponent}
];

 
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routingComponents=
[
  PaageNotFoundComponent,
  LoginComponent,
  SignupComponent,
  NoteComponent,
  ViewnoteComponent
];
