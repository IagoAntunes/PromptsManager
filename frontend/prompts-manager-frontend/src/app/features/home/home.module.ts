import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms'; // <-- Para os formulários
import { SharedModule } from 'src/app/shared/shared.module'; // <-- Para o app-custom-input

import { HomeRoutingModule } from './home-routing.module';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { PromptEditComponent } from './pages/prompt-edit/prompt-edit.component';
import { DashboardHomeComponent } from './pages/dashboard-home/dashboard-home.component';

@NgModule({
  declarations: [
    MainLayoutComponent,
    PromptEditComponent,
    DashboardHomeComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    ReactiveFormsModule, 
    SharedModule        
  ]
})
export class HomeModule { }