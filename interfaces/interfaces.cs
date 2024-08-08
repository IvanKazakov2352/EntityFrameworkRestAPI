using System.Text.Json.Serialization;

namespace TodoRestApi.interfaces
{
    public class Todo(string title)
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Title { get; set; } = title;
        public bool IsCompleted { get; set; } = false;
    }

    public class CreateTodoDto(string title)
    {
        public string Title { get; set; } = title;
    }

    public class UpdateTodoDto(string title, bool isCompleted)
    {
        public string Title { get; set; } = title;
        public bool IsCompleted { get; set; } = isCompleted;
    }

    public interface ITodoService
    {
        Task<Todo> AddTodo(string title);
        Task<Todo[]> GetTodos();
        Task<Todo> GetTodoById(Guid id);
        Task<Todo> DeleteTodo(Guid id);
        Task<Todo> UpdateTodoStatus(Guid id, UpdateTodoDto body);
    }
}
