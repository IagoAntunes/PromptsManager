import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    // Serviços singleton (como AuthService) já são 'providedIn: root'
    // Mas aqui você pode prover Interceptors
  ]
})
export class CoreModule { }