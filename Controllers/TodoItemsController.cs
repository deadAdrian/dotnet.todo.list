using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.DTOs;
using TodoList.Models;
using TodoList.Services;

namespace TodoList.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoItemsController: ControllerBase
{
    private readonly TodoContext _context;
    private readonly MappingService _mapper;
    
    public TodoItemsController(TodoContext context, MappingService mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoItemDTO>>> GetTodoItems()
    {
        return await _context.TodoItems
            .OrderBy(x => x.IsComplete)
            .Select(x => _mapper.ToDTO(x))
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        
        if(item == null) return NotFound();
        return _mapper.ToDTO(item);
    }

    [HttpPost]
    public async Task<ActionResult<TodoItemDTO>> PostTodoItem(UpsertItemDTO dto)
    {
        var item = _mapper.FromUpsertDTO(dto);
        _context.TodoItems.Add(item);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTodoItem), new { id = item.Id }, _mapper.ToDTO(item));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTodoItem(long id, UpsertItemDTO dto)
    {
        var item = await _context.TodoItems.FindAsync(id);

        if(item == null) return NotFound();

        if(dto.Name != null)
            item.Name = dto.Name;
        
        if(dto.IsComplete.HasValue)
            item.IsComplete = dto.IsComplete.Value;
        
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(long id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        if(item == null) return NotFound();

        _context.TodoItems.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
