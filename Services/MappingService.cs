using TodoList.Models;
using TodoList.DTOs;

namespace TodoList.Services;

public class MappingService
{
    public TodoItemDTO ToDTO(TodoItem item) => new(){
        Id = item.Id,
        Name = item.Name,
        IsComplete = item.IsComplete
    };

    public TodoItem FromDTO(TodoItemDTO dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        IsComplete = dto.IsComplete
    };

    public TodoItem FromUpsertDTO(UpsertItemDTO dto) => new()
    {
      Name = dto.Name,
      IsComplete = dto.IsComplete  
    };
}