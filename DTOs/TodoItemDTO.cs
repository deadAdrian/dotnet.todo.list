using System.ComponentModel;

namespace TodoList.DTOs;

public class TodoItemDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    [DefaultValue(false)]
    public bool? IsComplete { get; set; }
}

public class UpsertItemDTO
{
    public string? Name { get; set; }
    [DefaultValue(false)]
    public bool? IsComplete { get; set; }
}