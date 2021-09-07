import { HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { environment } from 'src/environments/environment';
import { ApiRestService } from './api-rest.service';

@Injectable({providedIn: 'root'})
export class CSRFService {
  constructor(private http:ApiRestService, private cookieService: CookieService) { }

baseUrl:string = environment.services.csrf.host;

  displayToken(){
    let csrftoken = this.cookieService.get('XSRF-TOKEN');
    console.log(csrftoken);
    return csrftoken;
  }

  GetToken(){
    this.http.get(this.baseUrl,'','api/AntiForgery/GenerateByEndpoint').subscribe(
      (data: HttpResponse<any>) => {
        this.displayToken();
      }
    );
  }

  SendRequest(body: any){
    this.http.post(this.baseUrl,'','WeatherForecast', body).subscribe(
      (data) => {
        console.log(data);
      }
    );
  }

  PutRequest(body: any){
    this.http.post(this.baseUrl,'','WeatherForecast', body).subscribe(
      (data) => {
        console.log(data);
      }
    );
  }
}
