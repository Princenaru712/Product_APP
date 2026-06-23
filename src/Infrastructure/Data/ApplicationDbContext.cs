using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Data.Identity
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

       
        public DbSet<Product> Products { get; set; }
        public DbSet<Item> Items { get; set; }

        

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}