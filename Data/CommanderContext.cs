using System;
using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt)
            : base(opt)
        {
        }

        public DbSet<Command> Commands { get; set; }

        public static void AddDefaultValues(CommanderContext context)
        {
            context.Commands.AddRange(
                new Command
                {
                    HowTo = "How to create migrations",
                    Line = "dotnet ef migrations add <Name of Migration>",
                    Platform = "EF Core"
                },
                new Command
                {
                    HowTo = "How to run migrations",
                    Line = "dotnet ef database update",
                    Platform = "EF Core"
                }
            );

            context.SaveChanges();
        }
    }
}