import { IPagination } from './models/pagination';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IAttachment } from './models/attachment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Intellebase';
  attachments: IAttachment[];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/attachments?pageSize=50').subscribe(
      (response: IPagination) => {
      this.attachments = response.data;
      }, error => {
      console.log(error);
      }
    );
  }
}
