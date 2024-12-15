using SteveLang.TodoApp.Domain.Entities;
using SteveLang.TodoApp.Domain.Repositories;

namespace SteveLang.TodoApp.Persistence
{
    public class TodoRepository : ITodoRepository
    {
        private readonly Dictionary<int, Todo> _todos = [];

        public TodoRepository()
        {
            _todos[1] = new Todo { Id = 1, Description = "Get milk", DateCreatedUtc = DateTime.UtcNow };
            _todos[2] = new Todo { Id = 2, Description = "Call Joe", DateCreatedUtc = DateTime.UtcNow };
            _todos[3] = new Todo { Id = 3, Description = "Go to Post Office", DateCreatedUtc = DateTime.UtcNow };
        }

        public async Task<IEnumerable<Todo>> GetTodos()
        {
            return await Task.FromResult(_todos.Values);
        }

        public async Task AddTodo(Todo todo)
        {
            var newId = _todos.Count + 1;
            todo.Id = newId;
            _todos[newId] = todo;

            await Task.CompletedTask;
        }

        public async Task DeleteTodo(int id)
        {
            _todos.Remove(id);

            await Task.CompletedTask;
        }
    }
}
