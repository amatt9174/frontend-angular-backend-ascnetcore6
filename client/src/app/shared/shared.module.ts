import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CdkStepperModule } from '@angular/cdk/stepper';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { PagerComponent } from './components/pager/pager.component';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { OrderTotalsComponent } from './components/order-totals/order-totals.component';
import { TextInputComponent } from './components/text-input/text-input.component';
import { StepperComponent } from './components/stepper/stepper.component';
import { BasketSummaryComponent } from './components/basket-summary/basket-summary.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent,
    OrderTotalsComponent,
    TextInputComponent,
    StepperComponent,
    BasketSummaryComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    PaginationModule.forRoot(),
    CarouselModule.forRoot(),
    BsDropdownModule.forRoot(),
    CdkStepperModule,
    RouterModule
  ],
  exports: [
    ReactiveFormsModule,
    FormsModule,
    PaginationModule,
    CarouselModule,
    BsDropdownModule,
    CdkStepperModule,
    PagingHeaderComponent,
    PagerComponent,
    OrderTotalsComponent,
    TextInputComponent,
    StepperComponent,
    BasketSummaryComponent
  ]
})
export class SharedModule { }
