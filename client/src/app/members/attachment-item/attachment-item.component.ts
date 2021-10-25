import { IAttachment } from 'src/app/shared/models/attachment';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-attachment-item',
  templateUrl: './attachment-item.component.html',
  styleUrls: ['./attachment-item.component.scss']
})
export class AttachmentItemComponent implements OnInit {
  @Input() attachment: IAttachment;

  constructor() { }

  ngOnInit(): void {
  }

}
