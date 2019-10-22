import { Component, OnInit } from '@angular/core';
import { MyAuthService } from './services/myauth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'app';

  public auth: number;

  constructor(private service: MyAuthService) {

  }

  ngOnInit() {
    this.service.getMyAuth().subscribe(result => {
      this.auth = result;
    }, error => console.error(error));
  }
}
