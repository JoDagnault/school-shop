namespace SchoolShop.Tests.Testing;

public sealed class DatabaseBackedApiTestFixture : IAsyncLifetime
{
    private readonly DatabaseBackedTestFixture _databaseFixture = new();
    private ApiTestFixture? _apiFixture;

    public SchoolShopPostgreSqlTestDatabase Database => _databaseFixture.Database;

    public ApiTestFixture Api =>
        _apiFixture ?? throw new InvalidOperationException("The API fixture has not been initialized.");

    public async Task InitializeAsync()
    {
        await _databaseFixture.InitializeAsync();

        _apiFixture = new ApiTestFixture(Database.ConnectionString);
    }

    public async Task ResetDatabaseAsync()
    {
        await _databaseFixture.ResetDatabaseAsync();
    }

    public async Task DisposeAsync()
    {
        if (_apiFixture is not null)
        {
            await _apiFixture.DisposeAsync();
        }

        await _databaseFixture.DisposeAsync();
    }
}
