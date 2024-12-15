namespace SteveLang.TodoApp.Domain.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime DateCreatedUtc { get; set; }
    }
}
