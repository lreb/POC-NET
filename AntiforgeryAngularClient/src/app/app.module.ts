import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { DemocsrfComponent } from './components/democsrf/democsrf.component';

import { HttpClientModule, HttpClientXsrfModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { CSRFInterceptor } from './interceptors/csrf.inteceptor';
import { CookieService } from 'ngx-cookie-service';

@NgModule({
  declarations: [
    AppComponent,
    DemocsrfComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    HttpClientXsrfModule.withOptions({ // helper to send csrf cookie
      cookieName: 'XSRF-TOKEN',
      headerName: 'X-XSRF-TOKEN',
    }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: CSRFInterceptor, multi: true }, // custom intercetor
    [CookieService] // third party service to read cookies
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
