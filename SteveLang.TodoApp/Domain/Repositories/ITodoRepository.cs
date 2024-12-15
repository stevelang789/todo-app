using SteveLang.TodoApp.Domain.Entities;

namespace SteveLang.TodoApp.Domain.Repositories
{
    public interface ITodoRepository
    {
        Task<IEnumerable<Todo>> GetTodos();
        Task AddTodo(Todo todo);
        Task DeleteTodo(int id);
    }
}
