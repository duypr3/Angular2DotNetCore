import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { NotFoundComponent } from './not-found/not-found.component';
<<<<<<< HEAD
import { StudentComponent } from './student/student.component';
=======
import { HomeComponent } from './home/home.component';
>>>>>>> origin/master


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NotFoundComponent,
<<<<<<< HEAD
    StudentComponent    
=======
    HomeComponent    
>>>>>>> origin/master
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
