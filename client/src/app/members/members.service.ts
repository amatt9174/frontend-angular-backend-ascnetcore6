import { IAttachment } from '../shared/models/attachment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPagination } from '../shared/models/pagination';
import { environment } from './../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAttachments(): Observable<IPagination> {
    return this.http.get<IPagination>(this.baseUrl + 'attachments?pageSize=50');
  }

  // getMembers(): Observable<IAttachment> {
  //   return this.http.get<IAttachment[]>(this.baseUrl + 'attachments');
  // }
}
