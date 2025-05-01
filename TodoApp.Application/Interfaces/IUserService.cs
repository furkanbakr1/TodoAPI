using TodoApp.Application.DTOs;

namespace TodoApp.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> RegisterAsync(CreateUserDto dto);
        Task<string?> LoginAsync(LoginDto dto); // Giriş başarılıysa token döner
    }
}
