using Microsoft.AspNetCore.Mvc;
using TodoRestApi.interfaces;

namespace TodoRestApi.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        private readonly ILogger<TodoController> _logger;

        public TodoController(ITodoService todoService, ILogger<TodoController> logger)
        {
            _todoService = todoService ?? throw new ArgumentNullException(nameof(todoService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("todos")]
        public Todo[] GetTodos()
        {
            var todos = new List<Todo>();
            return todos.ToArray();
        }

        [HttpGet("todos/{guid}")]
        public Todo GetTodoById(Guid guid)
        {
            return new Todo("dsfg");
        }

        [HttpPost("todos")]
        public Todo AddTodo([FromBody] CreateTodoDto body)
        {
            return new Todo("dsfg");
        }

        [HttpPut("todos/{guid}")]
        public Todo UpdateTodo(Guid guid, [FromBody] UpdateStatusDto body)
        {
            return new Todo("dsfg");
        }

        [HttpDelete("todos/{guid}")]
        public Todo DeleteTodo(Guid guid)
        {
            return new Todo("dsfg");
        }
    }
}
