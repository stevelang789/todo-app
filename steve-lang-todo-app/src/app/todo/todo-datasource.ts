import { DataSource } from '@angular/cdk/collections';
import { Observable, BehaviorSubject, switchMap } from 'rxjs';
import { Todo } from './todo';
import { TodoApiService } from './todo-api.service';

export class TodoDataSource extends DataSource<Todo> {
  todos$ = new BehaviorSubject<Todo[]>([]);

  constructor(private apiService: TodoApiService) {
    super();
  }

  connect(): Observable<Todo[]> {
    return this.todos$.asObservable();
  }

  disconnect(): void {
    this.todos$.complete();
  }

  loadTodos(): void {
    this.apiService.getTodos().subscribe(todos => {
      this.todos$.next(todos);
    })
  }

  addTodo(todo: Todo): void {
    this.apiService.addTodo(todo).pipe(
      switchMap(() => this.apiService.getTodos())
    ).subscribe(todos => {
      this.todos$.next(todos);
    })
  }

  deleteTodo(id: number): void {
    this.apiService.deleteTodo(id).pipe(
      switchMap(() => this.apiService.getTodos())
    ).subscribe(todos => {
      this.todos$.next(todos);
    })
  }
}
