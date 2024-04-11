using Microsoft.AspNetCore.Http.HttpResults;
using Pipeline.API.Entities.Models;
using PipelineDemo.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PipelineDemo.Tests.Utils;
using Pipeline.API.Endpoints;
using Pipeline.API.Handlers;

namespace PipelineDemo.Tests
{
    public class TodoInMemoryTests
    {
        [Fact]
        public async Task GetTodoReturnsNotFoundIfNotExists()
        {

            // Arrange
            await using var context = new MockDb().CreateDbContext();

            // Act
            var result = await TodoHandlers.GetTodoById(1, context);

            //Assert
            //Assert.IsType<Results<Ok<Todo>, NotFound>>(result);

            var notFoundResult = (NotFound)result;

            Assert.NotNull(notFoundResult);
        }

        [Fact]
        public async Task GetAllReturnsTodosFromDatabase()
        {

            // Shouldly
            // FluentAssertions


            // Arrange
            await using var context = new MockDb().CreateDbContext();

            context.Todos.Add(new Todo
            {
                Id = 3,
                Name = "Test title 1",
                IsComplete = false
            });

            context.Todos.Add(new Todo
            {
                Id = 4,
                Name = "Test title 2",
                IsComplete = true
            });

            await context.SaveChangesAsync();

            // Act
            var result = await TodoHandlers.GetAllTodos(context);

            //Assert
            //Assert.IsType<Ok<Todo[]>>(result);

            //Assert.NotNull(result);
            //Assert.NotEmpty(result);
            Assert.Collection(context.Todos, todo1 =>
            {
                Assert.Equal(3, todo1.Id);
                Assert.Equal("Test title 1", todo1.Name);
                Assert.False(todo1.IsComplete);
            }, todo2 =>
            {
                Assert.Equal(4, todo2.Id);
                Assert.Equal("Test title 2", todo2.Name);
                Assert.True(todo2.IsComplete);
            });
        }
    }
}
