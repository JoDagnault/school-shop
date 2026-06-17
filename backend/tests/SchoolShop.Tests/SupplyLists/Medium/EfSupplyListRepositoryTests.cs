using SchoolShop.Application.SupplyLists;
using SchoolShop.Domain.SupplyLists;
using SchoolShop.Infrastructure;
using SchoolShop.Infrastructure.SupplyLists;
using SchoolShop.Tests.TestInfrastructure;

namespace SchoolShop.Tests.SupplyLists.Medium;

[Collection("DatabaseBackedTests")]
public sealed class EfSupplyListRepositoryTests : SupplyListRepositoryTests, IAsyncLifetime
{
    private readonly DatabaseBackedTestFixture _fixture;
    private SchoolShopDbContext? _dbContext;

    public EfSupplyListRepositoryTests(DatabaseBackedTestFixture fixture)
    {
        _fixture = fixture;
    }

    public async Task InitializeAsync()
    {
        await _fixture.ResetDatabaseAsync();
        _dbContext = _fixture.Database.CreateDbContext();
    }

    public async Task DisposeAsync()
    {
        if (_dbContext is not null)
        {
            await _dbContext.DisposeAsync();
        }
    }

    protected override ISupplyListRepository CreateRepositoryContaining(params SupplyList[] supplyLists)
    {
        var dbContext = _dbContext
            ?? throw new InvalidOperationException("The test database has not been initialized.");

        dbContext.SupplyLists.AddRange(supplyLists.Select(SupplyListEntity.From));
        dbContext.SaveChanges();

        return new EfSupplyListRepository(dbContext);
    }
}
