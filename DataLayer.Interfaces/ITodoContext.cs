using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ITodoContext
    {
        DbSet<TodoItem> TodoItems { get; set; }


        public int SaveChanges();
        public int SaveChanges(bool acceptAllChangesOnSuccess);
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        public DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
