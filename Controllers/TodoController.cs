using _027TodoApi.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _027TodoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        
        [HttpPost]
        public async Task<ActionResult<Todo>> PostTask(Todo todo)
        {
            _context.Tasks.Add(todo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTasks), new { id = todo.Id }, todo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var todo = await _context.Tasks.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTask(int id, Todo todo)
        {
            if (id != todo.Id)
                return BadRequest();

            _context.Entry(todo).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
