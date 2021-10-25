import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MembersComponent } from './members.component';
import { AttachmentItemComponent } from './attachment-item/attachment-item.component';



@NgModule({
  declarations: [
    MembersComponent,
    AttachmentItemComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [MembersComponent]
})
export class MembersModule { }
