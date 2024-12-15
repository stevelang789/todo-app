using SteveLang.TodoApp.Contracts;

namespace SteveLang.TodoApp.Services.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoDto>> GetTodos();
        Task AddTodo(TodoDto dto);
        Task DeleteTodo(int id);
    }
}
