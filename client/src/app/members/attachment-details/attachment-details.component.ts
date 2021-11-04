import { IAttachment } from 'src/app/shared/models/attachment';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MembersService } from '../members.service';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-attachment-details',
  templateUrl: './attachment-details.component.html',
  styleUrls: ['./attachment-details.component.scss']
})
export class AttachmentDetailsComponent implements OnInit {
  attachment: IAttachment;

  constructor(private membersService: MembersService, private activatedRoute: ActivatedRoute,
    private bcService: BreadcrumbService) {
this.bcService.set('@attachmentDetails', ' ');
}

  ngOnInit(): void {
    this.loadAttachment();
  }

  loadAttachment(): void {
    this.membersService.getAttachment(this.activatedRoute.snapshot.paramMap.get('id')).subscribe(attachment => {
      this.attachment = attachment;
      this.bcService.set('@attachmentDetails', attachment.aType);
    }, error => {
      console.log(error);
    });
  }
}
