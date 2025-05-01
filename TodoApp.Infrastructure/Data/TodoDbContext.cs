using Microsoft.EntityFrameworkCore;
using TodoApp.Domain.Entities;

namespace TodoApp.Infrastructure.Data
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

        public DbSet<User> Users => Set<User>();
        public DbSet<Todo> Todos => Set<Todo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Todos)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
