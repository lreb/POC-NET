import { Component, OnInit } from '@angular/core';
import { CSRFService } from 'src/app/services/csrf.service';

@Component({
  selector: 'app-democsrf',
  templateUrl: './democsrf.component.html',
  styleUrls: ['./democsrf.component.css']
})
export class DemocsrfComponent implements OnInit {

  csrf = "NO CSRF VALUE";
  constructor(private tokenService: CSRFService) { }

  ngOnInit(): void {
  }

  requestCSRFToken() {
    this.tokenService.GetToken();
    this.showToken();
  }

  showToken() {
    this.csrf = this.tokenService.displayToken();
    console.log(this.csrf)
  }

  postWithCSRFToken() {
    var bodyRequest = {
      "number": 1010656
    };
    console.log(bodyRequest);
    this.tokenService.SendRequest(bodyRequest);
  }
}
