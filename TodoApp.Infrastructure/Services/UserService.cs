using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TodoApp.Application.DTOs;
using TodoApp.Application.Interfaces;
using TodoApp.Domain.Entities;
using TodoApp.Infrastructure.Data;
using TodoApp.Infrastructure.Security;

namespace TodoApp.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly TodoDbContext _context;
        private readonly string _jwtKey;

        public UserService(TodoDbContext context, IConfiguration config)
        {
            _context = context;
            _jwtKey = config["Jwt:Key"]!;
        }

        public async Task<UserDto?> RegisterAsync(CreateUserDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.Username == dto.Username))
                return null;

            var user = new User
            {
                Username = dto.Username,
                PasswordHash = PasswordHasher.Hash(dto.Password)
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserDto { Id = user.Id, Username = user.Username };
        }

        public async Task<string?> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == dto.Username);
            if (user == null || !PasswordHasher.Verify(dto.Password, user.PasswordHash))
                return null;

            return JwtGenerator.Generate(user.Id, user.Username, _jwtKey);
        }
    }
}
