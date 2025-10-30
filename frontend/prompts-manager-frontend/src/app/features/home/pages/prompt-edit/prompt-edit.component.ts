import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { PromptService } from 'src/app/core/services/prompt.service';

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
    const id = this.route.snapshot.paramMap.get('id');
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
        }
      });
    }
  }

  onSave() {
    if (this.promptForm.invalid) return;
    
    if (this.isNewPrompt) {
      console.log('Salvando NOVO prompt:', this.promptForm.value);
    } else {
      console.log('Atualizando prompt:', this.promptForm.value);
    }
  }
}