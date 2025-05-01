namespace TodoApp.Application.DTOs
{
    public class CreateTodoDto
    {
        public string Text { get; set; } = null!;
        public int UserId { get; set; }
    }
}
