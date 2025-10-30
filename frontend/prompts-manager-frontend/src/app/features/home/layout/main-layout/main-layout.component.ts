import { Component, inject, OnInit } from '@angular/core';
import { PromptService } from 'src/app/core/services/prompt.service';
import { PromptModel } from '../../models/prompt-model';
import { finalize, Observable, take } from 'rxjs';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss']
})
export class MainLayoutComponent implements OnInit  {
  isSidebarCollapsed = false;

  public prompts$: Observable<PromptModel[] | null>;

  constructor(private readonly _promptService: PromptService) {
    this.prompts$ = this._promptService.prompts$;
  }

  ngOnInit(): void {
    this._promptService.loadPromptsByUser().subscribe();
  }

  deletePrompt(promptId:string){
    this._promptService.deletePrompt(promptId).pipe(
      take(1),
      finalize(() => {
        //
      })
    ).subscribe({
      next: () => {
        console.log('Prompt deleted successfully');
      },
      error: (error) => {
        console.error('Error deleting prompt:', error);
      }
    });
  }

  toggleSidebar() {
    this.isSidebarCollapsed = !this.isSidebarCollapsed;
  }
}