import { IMember } from './../shared/models/member';
import { MembersService } from './members.service';
import { IAttachment } from '../shared/models/attachment';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.scss']
})
export class MembersComponent implements OnInit {
  attachments: IAttachment[];
  members: IMember[];

  constructor(private membersService: MembersService) { }

  ngOnInit(): void {
    this.getAttachments();
  }

  getAttachments(): void {
    this.membersService.getAttachments().subscribe(response => {
      this.attachments = response.data;
    }, error => {
      console.log(error);
    });
  }

  // getMembers(): void {
  //   this.membersService.getMembers().subscribe(response => {
  //     this.members = response;
  //   }, error => {
  //     console.log(error);
  //   });
  }
// }
