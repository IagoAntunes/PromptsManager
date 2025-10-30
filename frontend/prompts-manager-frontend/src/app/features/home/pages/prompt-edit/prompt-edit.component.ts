// ...existing code...
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { take } from 'rxjs';
import { PromptService } from 'src/app/core/services/prompt.service';
import { CreatePromptRequest } from '../../models/create-prompt-request';
import { UpdatePromptRequest } from '../../models/update-prompt-request';

@Component({
  selector: 'app-prompt-edit',
  templateUrl: './prompt-edit.component.html',
  styleUrls: ['./prompt-edit.component.scss']
})
export class PromptEditComponent implements OnInit {
  promptForm: FormGroup;
  isNewPrompt = true;

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private promptService: PromptService
  ) {
    this.promptForm = this.fb.group({
      title: ['', Validators.required],
      description: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.route.paramMap.subscribe((params: ParamMap) => {
      const id = params.get('id');

      if (id) {
        this.isNewPrompt = false;
        this.promptService.getPromptById(id).pipe(
          take(1),
        ).subscribe(prompt => {
          if (prompt) {
            this.promptForm.patchValue({
              title: prompt.title,
              description: prompt.description
            });
          } else {
            this.promptForm.reset();
          }
        });
      } else {
        this.isNewPrompt = true;
        this.promptForm.reset();
      }
    });
  }

  copyDescription(): void {
    const text = this.promptForm.get('description')?.value ?? '';

    if (!text) {
      console.log('Nada para copiar');
      return;
    }

    if (navigator.clipboard && navigator.clipboard.writeText) {
      navigator.clipboard.writeText(text).then(() => {
        console.log('Descrição copiada para a área de transferência');
      }).catch(err => {
        console.error('Falha ao copiar:', err);
      });
      return;
    }

    const ta = document.createElement('textarea');
    ta.value = text;
    document.body.appendChild(ta);
    ta.select();
    try {
      document.execCommand('copy');
      console.log('Descrição copiada (fallback)');
    } catch (err) {
      console.error('Falha no fallback de cópia:', err);
    }
    document.body.removeChild(ta);
  }

  onSave(): void {
    if (this.promptForm.invalid) return;
    
    if (this.isNewPrompt) {
      var request:CreatePromptRequest ={
        title: this.promptForm.get('title')?.value,
        description: this.promptForm.get('description')?.value
      };
      this.promptService.createPrompt(request).pipe(
        take(1),
      ).subscribe({
        next: (response) => {
          console.log('Prompt criado com sucesso:', response);
          this.promptForm.reset();
        },
        error: (error) => {
          console.error('Erro ao criar prompt:', error);
        }
      });
    } else {
      var updatePromptRequest:UpdatePromptRequest ={
        id: this.route.snapshot.paramMap.get('id')!,
        title: this.promptForm.get('title')?.value,
        description: this.promptForm.get('description')?.value
      };
      this.promptService.updatePrompt(updatePromptRequest).pipe(
        take(1),
      ).subscribe({
        next: (response) => {
          console.log('Prompt atualizado com sucesso:', response);
          this.promptForm.reset();
        },
        error: (error) => {
          console.error('Erro ao atualizar prompt:', error);
        }
      });
    }
  }
}