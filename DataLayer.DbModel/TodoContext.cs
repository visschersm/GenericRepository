using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataLayer.DbModel
{
    public class TodoContext : DbContext, ITodoContext
    {
        public TodoContext()
        {

        }

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {

        }

        public DbSet<TodoItem> TodoItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TodoContext;Trusted_Connection=True;MultipleActiveResultSets=true");
                //optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString())
                //    .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
