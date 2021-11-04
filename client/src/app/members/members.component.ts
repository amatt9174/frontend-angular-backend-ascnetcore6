import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

import { MembersParams } from './../shared/models/membersParams';
import { MembersService } from './members.service';
import { IAttachment } from '../shared/models/attachment';
import { IGroup } from '../shared/models/aGroup';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.scss']
})
export class MembersComponent implements OnInit {
  @ViewChild('search', {static: false}) searchTerm: ElementRef;
  attachments: IAttachment[];
  aGroups: IGroup[];
  totalCount: number;
  membersParams = new MembersParams();
  sortSelected = 'atypeAsc';
  sortOptions = [
    {name: 'Type', value: 'atypeAsc'},
    {name: 'Type Descending', value: 'atypeDesc'},
    {name: 'Group', value: 'agroupAsc'},
    {name: 'Group Descending', value: 'agroupDesc'}
  ];



  constructor(private membersService: MembersService) { }

  ngOnInit(): void {
    this.getAttachments();
    this.getGroups();
  }

  getAttachments(): void {
    this.membersService.getAttachments(this.membersParams).subscribe(response => {
      this.attachments = response.data;
      this.membersParams.pageNumber = response.pageIndex;
      this.membersParams.pageSize = response.pageSize;
      this.totalCount = response.count;
    }, error => {
      console.log(error);
    });
  }

  getGroups(): void {
    this.membersService.getGroups().subscribe(response => {
      this.aGroups = [{aGroup: 'All'}, ...response];
    }, error => {
      console.log(error);
    });
  }

  onGroupSelected(aGroup: string): void {
    this.membersParams.aGroup = aGroup;
    this.membersParams.pageNumber = 1;
    this.getAttachments();
  }

  onSortSelected(sort: string): void {
    this.membersParams.sort = sort;
    this.getAttachments();
  }

  onPageChanged(event: any): void {
    if (this.membersParams.pageNumber !== event) {
      this.membersParams.pageNumber = event;
      this.getAttachments();
      }
  }

  onSearch(): void {
    this.membersParams.search = this.searchTerm.nativeElement.value;
    this.membersParams.pageNumber = 1;
    this.getAttachments();
  }

  onReset(): void {
    this.searchTerm.nativeElement.value = '';
    this.membersParams = new MembersParams();
    this.getAttachments();
  }
}
