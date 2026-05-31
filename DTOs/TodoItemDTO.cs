namespace TodoList.DTOs;

public class TodoItemDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public bool? IsComplete { get; set; }
}

public class UpsertItemDTO
{
    public string? Name { get; set; }
    public bool? IsComplete { get; set; }
}