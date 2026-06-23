using Microsoft.EntityFrameworkCore;
using Domain.Entities; 
namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Item> Items { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}