import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MembersComponent } from './members.component';
import { AttachmentDetailsComponent } from './attachment-details/attachment-details.component';

const routes: Routes = [
  { path: '', component: MembersComponent },
  { path: ':id', component: AttachmentDetailsComponent,
    data: { breadcrumb: { alias: 'attachmentDetails' }} }
];


@NgModule({
  declarations: [

  ],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class MembersRoutingModule { }
