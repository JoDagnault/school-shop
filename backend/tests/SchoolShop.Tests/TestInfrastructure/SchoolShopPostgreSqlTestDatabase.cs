using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using SchoolShop.Domain.SupplyLists;
using SchoolShop.Infrastructure;
using SchoolShop.Infrastructure.SupplyLists;
using Testcontainers.PostgreSql;

namespace SchoolShop.Tests.TestInfrastructure;

public sealed class SchoolShopPostgreSqlTestDatabase : IAsyncDisposable
{
    private const string PostgreSqlImage = "postgres:18-alpine";
    private const string DatabaseName = "school_shop";
    private const string Username = "postgres";
    private const string Password = "postgres";

    private readonly PostgreSqlContainer _postgres = new PostgreSqlBuilder(PostgreSqlImage)
        .WithDatabase(DatabaseName)
        .WithUsername(Username)
        .WithPassword(Password)
        .Build();

    public string ConnectionString => _postgres.GetConnectionString();

    public async Task StartAsync()
    {
        await _postgres.StartAsync();

        await using var dbContext = CreateDbContext();
        await dbContext.Database.EnsureCreatedAsync();
    }

    public SchoolShopDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<SchoolShopDbContext>()
            .UseNpgsql(ConnectionString)
            .Options;

        return new SchoolShopDbContext(options);
    }

    public async Task ResetAsync()
    {
        await using var dbContext = CreateDbContext();

        var tables = TablesFor(dbContext);

        if (tables.Length == 0)
        {
            return;
        }

        var resetSql = $"TRUNCATE TABLE {string.Join(", ", tables)} RESTART IDENTITY CASCADE";

        await dbContext.Database.ExecuteSqlRawAsync(resetSql);
    }

    public async Task Persist(SupplyList supplyList)
    {
        await using var dbContext = CreateDbContext();

        dbContext.SupplyLists.Add(SupplyListEntity.From(supplyList));

        await dbContext.SaveChangesAsync();
    }

    private static string[] TablesFor(SchoolShopDbContext dbContext)
    {
        var sql = dbContext.GetService<ISqlGenerationHelper>();

        return dbContext.Model
            .GetEntityTypes()
            .Select(entityType => new
            {
                Name = entityType.GetTableName(),
                Schema = entityType.GetSchema()
            })
            .Where(table => table.Name is not null)
            .Select(table => sql.DelimitIdentifier(table.Name!, table.Schema))
            .Distinct()
            .ToArray();
    }

    public async ValueTask DisposeAsync()
    {
        await _postgres.DisposeAsync();
    }
}
