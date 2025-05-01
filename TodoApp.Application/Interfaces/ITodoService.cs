using TodoApp.Application.DTOs;

namespace TodoApp.Application.Interfaces
{
    public interface ITodoService
    {
        Task<List<TodoDto>> GetTodosByUserIdAsync(int userId);
        Task<TodoDto> CreateTodoAsync(CreateTodoDto dto);
        Task<bool> DeleteTodoAsync(int id);
        Task<bool> ToggleTodoCompleteAsync(int id);
    }
}
