import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { NgbAlertModule, NgbDropdownModule, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { CustomInputComponent } from './components/custom-input/custom-input.component';

const NG_BOOTSTRAP_MODULES = [
  NgbAlertModule,
  NgbDropdownModule,
  NgbModalModule
];

@NgModule({
  declarations: [
    CustomInputComponent
  ],
  imports: [
    CommonModule,
    ...NG_BOOTSTRAP_MODULES 
  ],
  exports: [
    CustomInputComponent,
    ...NG_BOOTSTRAP_MODULES 
  ]
})
export class SharedModule { }