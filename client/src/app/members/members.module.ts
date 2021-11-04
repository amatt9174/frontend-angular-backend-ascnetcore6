import { AttachmentDetailsComponent } from './attachment-details/attachment-details.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MembersComponent } from './members.component';
import { AttachmentItemComponent } from './attachment-item/attachment-item.component';
import { SharedModule } from '../shared/shared.module';
import { MembersRoutingModule } from './members-routing.module';



@NgModule({
  declarations: [
    MembersComponent,
    AttachmentItemComponent,
    AttachmentDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    MembersRoutingModule
  ],
  exports: [
  ]
})
export class MembersModule { }
