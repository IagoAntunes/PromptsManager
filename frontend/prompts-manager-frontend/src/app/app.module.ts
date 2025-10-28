import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http'; 

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module'; 
import { AuthInterceptor } from './core/interceptors/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule, 
    CoreModule       
  ],
  providers: [
  {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true // Permite múltiplos interceptors
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }