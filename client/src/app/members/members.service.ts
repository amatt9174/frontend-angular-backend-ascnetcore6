import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { MembersParams } from './../shared/models/membersParams';
import { IAttachment } from '../shared/models/attachment';
import { IPaginationAttachments } from '../shared/models/paginationAttachments';
import { environment } from '../../environments/environment';
import { IGroup } from '../shared/models/aGroup';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class MembersService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getAttachments(membersParams: MembersParams): Observable<IPaginationAttachments> {
    let params = new HttpParams();

    // if (membersParams.aGroup === 'All') {
    //   membersParams.aGroup = '';
    // }

    if (membersParams.aGroup !== 'All') {
      params = params.append('agroup', membersParams.aGroup);
    }

    if (membersParams.search) {
      params = params.append('search', membersParams.search);
    }

    params = params.append('sort', membersParams.sort);
    params = params.append('pageIndex', membersParams.pageNumber.toString());
    params = params.append('pageSize', membersParams.pageSize.toString());

    return this.http.get<IPaginationAttachments>(this.baseUrl + 'attachments', { observe: 'response', params })
      .pipe(
        map(response => {
          return response.body;
        })
      );
  }

  getAttachment(id: string): Observable<IAttachment> {
    return this.http.get<IAttachment>(this.baseUrl + 'attachments/' + id);
  }

  getGroups(): Observable<IGroup[]> {
    return this.http.get<IGroup[]>(this.baseUrl + 'attachments/groups');
  }
}
