using Microsoft.AspNetCore.Mvc;
using SteveLang.TodoApp.Contracts;
using SteveLang.TodoApp.Services.Interfaces;

namespace SteveLang.TodoApp.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TodoController : ControllerBase
    {
        private readonly ILogger<TodoController> _logger;
        private readonly ITodoService _todoService;

        public TodoController(
            ILogger<TodoController> logger,
            ITodoService todoService)
        {
            _logger = logger;
            _todoService = todoService;
        }

        [HttpGet()]
        public async Task<IEnumerable<TodoDto>> GetTodos()
        {
            return await _todoService.GetTodos();
        }

        [HttpPost()]
        public async Task AddTodo(TodoDto todo)
        {
            await _todoService.AddTodo(todo);
        }

        [HttpPost()]
        public async Task DeleteTodo([FromBody] int id)
        {
            await _todoService.DeleteTodo(id);
        }
    }
}
