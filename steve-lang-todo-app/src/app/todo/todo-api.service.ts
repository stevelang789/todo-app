import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Todo } from './todo';

@Injectable({
  providedIn: 'root'
})
export class TodoApiService {
  private readonly url = 'http://localhost:8000/api/Todo';

  constructor(private httpClient: HttpClient) { }

  getTodos(): Observable<Todo[]> {
    return this.httpClient.get<Todo[]>(`${this.url}/GetTodos`);
  }

  addTodo(todo: Todo): Observable<void> {
    return this.httpClient.post<void>(`${this.url}/AddTodo`, todo);
  }

  deleteTodo(id: number): Observable<void> {
    return this.httpClient.post<void>(`${this.url}/DeleteTodo`, id);
  }
}
