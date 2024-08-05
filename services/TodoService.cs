using TodoRestApi.interfaces;

namespace TodoRestApi.services
{
    public class TodoService : ITodoService
    {
        private List<Todo> _todos = new List<Todo>();

        public Todo AddTodo(string title) 
        {
            Todo todo = new(title);
            _todos.Add(todo);
            return todo;
        }

        public Todo DeleteTodo(Guid Id)
        {
            Todo todo = _todos.Find((todo) => todo.Id == Id)! ?? throw new KeyNotFoundException("Задача не найдена в списке");
            _todos.Remove(todo);
            return todo;
        }

        public Todo[] GetTodos()
        {
            return _todos.ToArray();
        }

        public Todo GetTodoById(Guid Id) 
        {
            return _todos.Find((todo) => todo.Id == Id)! ?? throw new KeyNotFoundException("Задача не найдена в списке");
        }

        public Todo UpdateStatus(Guid Id, bool status)
        {
            int index = _todos.FindIndex((todo) => todo.Id == Id);
            if (index == -1)
            {
                throw new KeyNotFoundException("Задача не найдена в списке");
            }
            _todos[index].IsCompleted = status;
            return _todos[index];
        }
    }
}
