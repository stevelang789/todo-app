import { Component } from '@angular/core';
import { TodoComponent } from './todo/todo.component';

@Component({
  selector: 'app-root',
  imports: [
    TodoComponent
  ],
  template: `
    <main>
      <header class="brand-name">
        <img class="brand-logo" src="/assets/todo-app.png" alt="logo" aria-hidden="true" />
      </header>
      <section class="content">
        <app-todo></app-todo>
      </section>
    </main>
  `,
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Steve Lang\'s Todo App';
}
