import { query } from '@angular/animations';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, of, tap } from 'rxjs';
import { CreatePromptRequest } from 'src/app/features/home/models/create-prompt-request';
import { PromptModel } from 'src/app/features/home/models/prompt-model';
import { UpdatePromptRequest } from 'src/app/features/home/models/update-prompt-request';

@Injectable({
  providedIn: 'root'
})
export class PromptService {
  private url = 'https://localhost:7207/api' + '/Prompt';

  private promptsState$ = new BehaviorSubject<PromptModel[] | null>(null);
  public prompts$ = this.promptsState$.asObservable();


  constructor(
    private http: HttpClient,
  ) { }

  loadPromptsByUser(): Observable<PromptModel[]> {
    const currentState = this.promptsState$.getValue();
    if (currentState) {
      return of(currentState); 
    }

    return this.http.get<PromptModel[]>(this.url).pipe(
      tap(prompts => {
        this.promptsState$.next(prompts);
      })
    );
  }

  private refreshPromptsFromServer(): Observable<PromptModel[]> {
    return this.http.get<PromptModel[]>(this.url).pipe(
      tap(prompts => this.promptsState$.next(prompts))
    );
  }

  getPromptById(id: string): Observable<PromptModel | undefined> {
    const currentState = this.promptsState$.getValue();

    if (currentState) {
      const promptFromCache = currentState.find(p => p.id === id);
      if (promptFromCache) {
        return of(promptFromCache); 
      }
    }

    return this.http.get<PromptModel>(`${this.url}/${id}`);
  }

  createPrompt(request:CreatePromptRequest) : Observable<any>{
    return this.http.post<any>(`${this.url}`, request).pipe(
      tap(() => {
        this.refreshPromptsFromServer().subscribe({ error: () => {} });
      })
    );
  }

  updatePrompt(request:UpdatePromptRequest) : Observable<any>{
    return this.http.put<any>(`${this.url}`, request).pipe(
      tap(() => {
        this.refreshPromptsFromServer().subscribe({ error: () => {} });
      })
    );
  }

  deletePrompt(id:string) : Observable<any>{
    return this.http.delete(`${this.url}`, { params: { promptId: id } }).pipe(
      tap(() => {
        this.refreshPromptsFromServer().subscribe({ error: () => {} });
      })
    );
  }

}
