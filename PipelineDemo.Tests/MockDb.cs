using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pipeline.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDemo.Tests.Utils
{
    public class MockDb : IDbContextFactory<TodoDbContext>
    { 

       
        public TodoDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<TodoDbContext>()
                .UseInMemoryDatabase($"InMemoryTestDb-{DateTime.Now.ToFileTimeUtc()}")
                .Options;

            return new TodoDbContext(options);
        }

    }
}
