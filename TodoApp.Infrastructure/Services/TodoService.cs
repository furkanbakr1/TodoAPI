using Microsoft.EntityFrameworkCore;
using TodoApp.Application.DTOs;
using TodoApp.Application.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Infrastructure.Data;

namespace TodoApp.Infrastructure.Services
{
    public class TodoService : ITodoService
    {
        private readonly TodoDbContext _context;

        public TodoService(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<List<TodoDto>> GetTodosByUserIdAsync(int userId)
        {
            return await _context.Todos
                .Where(t => t.UserId == userId)
                .Select(t => new TodoDto
                {
                    Id = t.Id,
                    Text = t.Text,
                    IsCompleted = t.IsCompleted
                }).ToListAsync();
        }

        public async Task<TodoDto> CreateTodoAsync(CreateTodoDto dto)
        {
            var todo = new Todo
            {
                Text = dto.Text,
                UserId = dto.UserId,
                IsCompleted = false
            };

            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();

            return new TodoDto { Id = todo.Id, Text = todo.Text, IsCompleted = false };
        }

        public async Task<bool> DeleteTodoAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return false;

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ToggleTodoCompleteAsync(int id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null) return false;

            todo.IsCompleted = !todo.IsCompleted;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
