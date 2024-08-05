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

    public class UpdateStatusDto(bool status)
    {
        public bool IsCompleted { get; set; } = status;
    }

    public interface ITodoService
    {
        Todo AddTodo(string title);
        Todo DeleteTodo(Guid id);
        Todo[] GetTodos();
        Todo GetTodoById(Guid id);
        Todo UpdateStatus(Guid id, bool status);
    }
}
