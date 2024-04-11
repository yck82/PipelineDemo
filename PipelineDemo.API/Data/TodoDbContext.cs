using Microsoft.EntityFrameworkCore;
using PipelineDemo.API.Entities.Models;

namespace PipelineDemo.API.Data
{
    public class TodoDbContext: DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
