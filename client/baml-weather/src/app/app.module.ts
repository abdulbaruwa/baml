import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { MatInputModule, MatButtonModule, MatSelectModule, MatIconModule, MatToolbar, MatMenuModule, MatSliderModule, MatCardModule } from '@angular/material';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTabsModule } from '@angular/material/tabs';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavbarComponent } from './navbar/navbar.component';
import { WeatherComponent } from './weather/weather.component';
import { AppRoutingModule } from './app-routing/app-routing.module';

@NgModule({
    declarations: [
      AppComponent,
      NavbarComponent,
      WeatherComponent
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
      MatMenuModule,
      MatSliderModule,
      MatCardModule,
      MatTabsModule,
      AppRoutingModule
    ],
    providers: [],
    bootstrap: [AppComponent]
  })

export class AppModule { }
