import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { CreateComponent } from './components/create/create.component';
import { IndexComponent } from './components/index/index.component';
import { EditComponent } from './components/edit/edit.component';
import { AppRoutingModule } from './app-routing.module';  

import { HttpClientModule } from '@angular/common/http';  
import { FormsModule, ReactiveFormsModule } from "@angular/forms";  
import { CustomerService } from './services/customer.service'; 
import { SlimLoadingBarModule } from 'ng2-slim-loading-bar';

@NgModule({
  declarations: [
    AppComponent,
    CreateComponent,
    IndexComponent,
    EditComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,  
    AppRoutingModule,  
    FormsModule,
    ReactiveFormsModule,
    SlimLoadingBarModule
  ],
  providers: [CustomerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
