namespace SchoolShop.Tests.Testing;

public sealed class DatabaseBackedTestFixture : IAsyncLifetime
{
    public SchoolShopPostgreSqlTestDatabase Database { get; } = new();

    public async Task InitializeAsync()
    {
        await Database.StartAsync();
    }

    public async Task ResetDatabaseAsync()
    {
        await Database.ResetAsync();
    }

    public async Task DisposeAsync()
    {
        await Database.DisposeAsync();
    }
}
