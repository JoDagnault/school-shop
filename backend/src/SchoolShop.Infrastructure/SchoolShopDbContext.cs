using Microsoft.EntityFrameworkCore;
using SchoolShop.Infrastructure.SupplyLists;

namespace SchoolShop.Infrastructure;

public sealed class SchoolShopDbContext(DbContextOptions<SchoolShopDbContext> options) : DbContext(options)
{
    public DbSet<SupplyListEntity> SupplyLists => Set<SupplyListEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolShopDbContext).Assembly);
    }
}
