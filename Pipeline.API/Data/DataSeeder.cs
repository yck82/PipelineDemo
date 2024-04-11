using Microsoft.EntityFrameworkCore;
using Pipeline.API.Data;
using Pipeline.API.Entities.Models;

namespace Pipeline.API.Data
{
    public static class DataSeeder
    {
        public static void Initialize(TodoDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Todos.Any())
            {
                return;   // DB has been seeded
            }

            var todos = new List<Todo>
            {
                new Todo { Id = 1, Name = "Werken", IsComplete = false },
                new Todo { Id = 2, Name = "Boodschappen", IsComplete = false}
            };

            foreach (Todo s in todos)
            {
                context.Todos.Add(s);
            }
            context.SaveChanges();
        }
    }
}
