using Final_Web_Project.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Final_Web_Project.Tests.Factory
{
    public static class ContextFactory
    {
        public static FinalWebProjectDbContext Initializer()
        {
            var options = new DbContextOptionsBuilder<FinalWebProjectDbContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

            return new FinalWebProjectDbContext(options);
        }
    }
}
