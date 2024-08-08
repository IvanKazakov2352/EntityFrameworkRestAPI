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
        public async Task<Todo[]> GetTodos()
        {
            try
            {
                var todos = await _todoService.GetTodos();
                return todos;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.ToString());
                throw new Exception(ex.ToString());
            }

        }

        [HttpPost("todos")]
        public async Task<Todo> AddTodo([FromBody] CreateTodoDto body)
        {
            try
            {
                var todo = await _todoService.AddTodo(body.Title);
                return todo;
            } catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex.ToString());
                throw new KeyNotFoundException(ex.ToString());
            }
        }

        [HttpGet("todos/{id}")]
        public async Task<Todo> GetTodoById(Guid id)
        {
            try
            {
                var todo = await _todoService.GetTodoById(id);
                return todo;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex.ToString());
                throw new KeyNotFoundException(ex.ToString());
            }

        }

        [HttpDelete("todos/{id}")]
        public async Task<Todo> DeleteTodo(Guid id)
        {
            try
            {
                var todo = await _todoService.DeleteTodo(id);
                return todo;
            }
            catch(KeyNotFoundException ex)
            {
                _logger.LogError(ex.ToString());
                throw new KeyNotFoundException(ex.ToString());
            }
        }

        [HttpPut("todos/{id}")]
        public async Task<Todo> UpdateTodoStatus(Guid id, [FromBody] UpdateTodoDto body)
        {
            try
            {
                var todo = await _todoService.UpdateTodoStatus(id, body);
                return todo;
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogError(ex.ToString());
                throw new KeyNotFoundException(ex.ToString());
            }
        }
    }
}
