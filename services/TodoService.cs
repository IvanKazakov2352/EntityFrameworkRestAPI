using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Json;
using TodoRestApi.interfaces;
using TodoRestApi.Utils;

namespace TodoRestApi.services
{
    public class TodoService : ITodoService
    {
        private readonly DatabaseContext _dbContext;

        public TodoService(DatabaseContext context)
        {
            _dbContext = context;
        }

        public async Task<Todo> AddTodo(string title)
        {
            var todo = new Todo(title);
            await _dbContext.Todos.AddAsync(todo);
            await _dbContext.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo[]> GetTodos()
        {
            var todos = await _dbContext.Todos.ToArrayAsync();
            return todos;
        }

        public async Task<Todo> GetTodoById(Guid id)
        {
            var todo = await _dbContext.Todos.FindAsync(id);
            if(todo == null)
            {
                throw new KeyNotFoundException("Task not found");
            }
            return todo;
        }

        public async Task<Todo> DeleteTodo(Guid id)
        {
            var todo = await _dbContext.Todos.FindAsync(id);
            if (todo == null)
            {
                throw new KeyNotFoundException("Task not found");
            }
            _dbContext.Todos.Remove(todo);
            await _dbContext.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo> UpdateTodoStatus(Guid Id, UpdateTodoDto body)
        {
            var todo = await _dbContext.Todos.FindAsync(Id);
            if (todo == null)
            {
                throw new KeyNotFoundException("Task not found");
            }
            todo.IsCompleted = body.IsCompleted;
            todo.Title = body.Title;
            await _dbContext.SaveChangesAsync();
            return todo;
        }
    }
}
