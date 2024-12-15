import { AfterViewInit, Component, inject, OnInit, viewChild } from '@angular/core';
import { FormGroup, FormGroupDirective, NonNullableFormBuilder, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatRadioModule } from '@angular/material/radio';
import { MatSelectModule } from '@angular/material/select';
import { MatSortModule } from '@angular/material/sort';
import { MatTable, MatTableModule } from '@angular/material/table';
import { TodoDataSource } from './todo-datasource';
import { nullOrWhiteSpaceValidator } from '/common/null-or-whitespace.validator';
import { Todo } from './todo';
import { TodoApiService } from './todo-api.service';
import { TodoForm } from './todo-form';

@Component({
  selector: 'app-todo',
  imports: [
    MatButtonModule,
    MatCardModule,
    MatInputModule,
    MatPaginatorModule,
    MatRadioModule,
    MatSelectModule,
    MatSortModule,
    MatTableModule,
    ReactiveFormsModule
  ],
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.scss'
})
export class TodoComponent implements OnInit, AfterViewInit {
  todoForm: FormGroup<TodoForm>;
  table = viewChild(MatTable<Todo>);
  formGroupDirective = viewChild(FormGroupDirective);
  dataSource = new TodoDataSource(this.apiService);
  displayedColumns = ['description', 'action'];

  constructor(
    nnfb: NonNullableFormBuilder,
    private apiService: TodoApiService) {
      this.todoForm = nnfb.group({
        description: ['', nullOrWhiteSpaceValidator]
      });
  }

  ngOnInit(): void {
    this.dataSource.loadTodos();
  }

  ngAfterViewInit(): void {
    this.table()!.dataSource = this.dataSource;
  }

  add(): void {
    if (this.todoForm.valid) {
      this.dataSource.addTodo({
        id: 0,
        description: this.todoForm.value.description!
      });
      this.formGroupDirective()!.resetForm();
    }
  }

  delete(id: number): void {
    this.dataSource.deleteTodo(id);
  }
}
