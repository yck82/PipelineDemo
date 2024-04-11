using Microsoft.EntityFrameworkCore;
using Pipeline.API.Data;
using Pipeline.API.Entities.Dtos;
using Pipeline.API.Entities.Models;
using System;

namespace Pipeline.API.Handlers
{
    public class TodoHandlers
    {
        public static async Task<IResult> GetAllTodos(TodoDbContext db) =>
            TypedResults.Ok(await db.Todos.Select(x => new TodoItemDTO(x)).ToArrayAsync());


        public static async Task<IResult> GetCompleteTodos(TodoDbContext db) =>
            TypedResults.Ok(await db.Todos.Where(t => t.IsComplete).ToListAsync());

        public static async Task<IResult> GetTodoById(int id, TodoDbContext db) =>
            await db.Todos.FindAsync(id)
            is Todo todo
            ? TypedResults.Ok(todo)
            : TypedResults.NotFound();

        public static async Task<IResult> CreateTodo(Todo todo, TodoDbContext db)
        {
            db.Todos.Add(todo);
            await db.SaveChangesAsync();
            return Results.Created($"/todoitems/{todo.Id}", todo);
        }

        public static async Task<IResult> UpdateTodo(int id, Todo inputTodo, TodoDbContext db)
        {
            var todo = await db.Todos.FindAsync(id);
            if (todo == null) return Results.NotFound();

            todo.Name = inputTodo.Name;
            todo.IsComplete = inputTodo.IsComplete;
            await db.SaveChangesAsync();

            return Results.NoContent();
        }

        public static async Task<IResult> DeleteTodo(int id, TodoDbContext db)
        {
            if (await db.Todos.FindAsync(id) is Todo todo)
            {
                db.Todos.Remove(todo);
                await db.SaveChangesAsync();
                return TypedResults.NoContent();
            }

            return TypedResults.NotFound();
            //var todo = await db.Todos.FindAsync(id);
            //if (todo == null) return Results.NotFound();

            //db.Todos.Remove(todo);
            //await db.SaveChangesAsync();
            //return Results.NoContent();
        }
    }

}
