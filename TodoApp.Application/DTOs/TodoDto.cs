namespace TodoApp.Application.DTOs
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Text { get; set; } = null!;
        public bool IsCompleted { get; set; }
    }
}
