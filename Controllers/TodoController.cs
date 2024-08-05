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
            try
            {
                return _todoService.GetTodos();
            }
            catch (BadHttpRequestException ex)
            {
                _logger.LogError(ex, "An error occurred while getting the todo by id.");
                throw new BadHttpRequestException(ex.Message);
            }
        }

        [HttpGet("todos/{guid}")]
        public Todo GetTodoById(Guid guid)
        {
            try
            {
                return _todoService.GetTodoById(guid);
            }
            catch (BadHttpRequestException ex)
            {
                _logger.LogError(ex, "An error occurred while getting the todo by id.");
                throw new BadHttpRequestException(ex.Message);
            }
        }

        [HttpPost("todos")]
        public Todo AddTodo([FromBody] CreateTodoDto body)
        {
            try
            {
                return _todoService.AddTodo(body.Title);
            }
            catch (BadHttpRequestException ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new todo.");
                throw new BadHttpRequestException(ex.Message);
            }
        }

        [HttpPut("todos/{guid}")]
        public Todo UpdateTodo(Guid guid, [FromBody] UpdateStatusDto body)
        {
            try
            {
                return _todoService.UpdateStatus(guid, body.IsCompleted);
            }
            catch (BadHttpRequestException ex)
            {
                _logger.LogError(ex, "An error occurred while updating the todo.");
                throw new BadHttpRequestException(ex.Message);
            }
        }

        [HttpDelete("todos/{guid}")]
        public Todo DeleteTodo(Guid guid)
        {
            try
            {
                return _todoService.DeleteTodo(guid);
            }
            catch (BadHttpRequestException ex)
            {
                _logger.LogError(ex, "An error occurred while deleting the todo.");
                throw new BadHttpRequestException(ex.Message);
            }
        }
    }
}
