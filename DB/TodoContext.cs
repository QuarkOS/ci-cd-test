using Microsoft.EntityFrameworkCore;

namespace _027TodoApi.DB
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

        public DbSet<Todo> Tasks { get; set; }
    }
}
