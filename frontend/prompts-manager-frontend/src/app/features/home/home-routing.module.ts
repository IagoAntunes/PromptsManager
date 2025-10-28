import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { DashboardHomeComponent } from './pages/dashboard-home/dashboard-home.component';
import { PromptEditComponent } from './pages/prompt-edit/prompt-edit.component';

const routes: Routes = [
  {
    path: '',
    component: MainLayoutComponent, 
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' }, 
      { path: 'dashboard', component: DashboardHomeComponent },
      { path: 'prompt/new', component: PromptEditComponent },
      { path: 'prompt/:id', component: PromptEditComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }