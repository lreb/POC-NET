import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpEvent, HttpHandler, HttpRequest, HttpXsrfTokenExtractor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class CSRFInterceptor implements HttpInterceptor {

  constructor(private cookieService: CookieService, private xsrfTokenExtractor: HttpXsrfTokenExtractor ) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    let xsrfToken = this.xsrfTokenExtractor.getToken();
    console.info(`xsrfToken: ${xsrfToken}`);

    const fakeAuthToken = 'fake-jwt-token';

    console.info(`Method: ${req.method}`);
    if(req.method === 'POST' || req.method === 'PUT' || req.method === 'DELETE' || req.method === 'OPTIONS'
    || req.method === 'HEAD') {
      let antiforgeryToken = this.cookieService.get('XSRF-TOKEN');
      console.log(antiforgeryToken);
      req = req.clone({
        setHeaders: {
          'Content-Type': 'application/json',
          'X-XSRF-TOKEN': antiforgeryToken, // attach CSRF token
          'Authorization': `Bearer ${fakeAuthToken}` // example to send json web token
        },
        withCredentials: true // send cookies in each request
      });
    }
    else if (req.method === 'GET') {
      req = req.clone({
        setHeaders: {
          'Content-Type': 'application/json',
        },
        withCredentials: true
      });
    }

    console.log(req);
    return next.handle(req);
  }
}
