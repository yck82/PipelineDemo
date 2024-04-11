using Microsoft.EntityFrameworkCore;
using Pipeline.API.Entities.Models;

namespace Pipeline.API.Data
{
    public class TodoDbContext: DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options)
            : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    DataSeeder.Initialize(modelBuilder);
        //}
    }
}
