namespace TodoApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        // Navigation
        public ICollection<Todo> Todos { get; set; } = new List<Todo>();
    }
}
