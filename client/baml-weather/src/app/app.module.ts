import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { MatInputModule, MatButtonModule, MatSelectModule, MatIconModule, MatToolbar, MatMenuModule } from '@angular/material';
import { MatToolbarModule } from '@angular/material/toolbar';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './navbar/navbar.component';

@NgModule({
    declarations: [
      AppComponent,
      NavbarComponent
    ],
  
    imports: [
      BrowserModule,
      FormsModule,
      HttpModule,
      BrowserAnimationsModule,
      MatInputModule, 
      MatButtonModule,
      MatSelectModule,
      MatIconModule,
      MatToolbarModule,
      MatMenuModule
    ],
    providers: [],
    bootstrap: [AppComponent]
  })

export class AppModule { }
