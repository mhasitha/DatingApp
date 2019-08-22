import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  values:any;
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getValues();
  }
  registerToggle(){
    this.registerMode=true;
  }
  getValues() {
    this.http.get('https://localhost:44314/api/values')
    .subscribe(response => { this.values = response;
    // tslint:disable-next-line:no-shadowed-variable
    }, error => { console.log(error); });
  }
  cancelRegisterMode(registerMode:boolean){
    this.registerMode = registerMode;
  }
}
