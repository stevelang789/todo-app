using SteveLang.TodoApp.Contracts;
using SteveLang.TodoApp.Domain.Entities;
using SteveLang.TodoApp.Domain.Repositories;
using SteveLang.TodoApp.Services.Interfaces;

namespace SteveLang.TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<IEnumerable<TodoDto>> GetTodos()
        {
            var todos = await _todoRepository.GetTodos();

            var dtos = todos.Select(todo => new TodoDto
            {
                Id = todo.Id,
                Description = todo.Description
            });

            return dtos;
        }

        public async Task AddTodo(TodoDto dto)
        {
            var todo = new Todo
            {
                Description = dto.Description,
                DateCreatedUtc = DateTime.UtcNow
            };

            await _todoRepository.AddTodo(todo);
        }

        public async Task DeleteTodo(int id)
        {
            await _todoRepository.DeleteTodo(id);
        }
    }
}
