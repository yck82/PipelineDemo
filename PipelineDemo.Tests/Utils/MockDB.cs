using Microsoft.EntityFrameworkCore;
using Pipeline.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PipelineDemo.Tests.Utils
{
    public class MockDB : IDbContextFactory<TodoDbContext>
    {
        public TodoDbContext CreateDbContext
        {

        }
    }
}
