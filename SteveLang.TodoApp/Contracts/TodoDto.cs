namespace SteveLang.TodoApp.Contracts
{
    public record TodoDto
    {
        public int Id { get; init; }
        public string Description { get; init; } = string.Empty;
    }
}
