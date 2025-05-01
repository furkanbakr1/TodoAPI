namespace TodoApp.Domain.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public bool IsCompleted { get; set; } = false;

        // Foreign Key
        public int UserId { get; set; }

        // Navigation
        public User User { get; set; } = null!;
    }
}
