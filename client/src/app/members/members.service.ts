import { IAttachment } from '../shared/models/attachment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPaginationAttachments } from '../shared/models/paginationAttachments';
import { environment } from './../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAttachments(): Observable<IPaginationAttachments> {
    return this.http.get<IPaginationAttachments>(this.baseUrl + 'attachments?pageSize=50');
  }

  // getMembers(): Observable<IAttachment> {
  //   return this.http.get<IAttachment[]>(this.baseUrl + 'attachments');
  // }
}
