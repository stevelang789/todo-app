using SteveLang.TodoApp.Domain.Entities;
using Xunit;

namespace SteveLang.TodoApp.Persistence.Tests
{
    public class TodoRepositoryTests
    {
        [Fact]
        public async Task GetTodos_ShouldGetTodos()
        {
            var todoRepository = new TodoRepository();
            var todos = await todoRepository.GetTodos();

            Assert.Equal(3, todos.Count());
        }

        [Fact]
        public async Task AddTodo_ShouldIncreaseCountOfTodosByOne()
        {
            var todoRepository = new TodoRepository();
            var todosBefore = await todoRepository.GetTodos();
            var countOfTodosBefore = todosBefore.Count();
            await todoRepository.AddTodo(new Todo
            {
                Description = "Test"
            });
            var todosAfter = await todoRepository.GetTodos();
            var countOfTodosAfter = todosAfter.Count();

            Assert.True(countOfTodosAfter == countOfTodosBefore + 1);
        }

        [Fact]
        public async Task DeleteTodo_ShouldDecreaseCountOfTodosByOne()
        {
            var todoRepository = new TodoRepository();
            var todosBefore = await todoRepository.GetTodos();
            var countOfTodosBefore = todosBefore.Count();
            await todoRepository.DeleteTodo(id: 3);
            var todosAfter = await todoRepository.GetTodos();
            var countOfTodosAfter = todosAfter.Count();

            Assert.True(countOfTodosAfter == countOfTodosBefore - 1);
        }
    }
}
