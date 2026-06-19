namespace SchoolShop.Tests.Testing;

public sealed class ApiTestFixture : IAsyncDisposable
{
    public ApiTestFixture(string connectionString)
    {
        Application = new SchoolShopApiApplication(connectionString);
    }

    public SchoolShopApiApplication Application { get; }

    public HttpClient CreateClient()
    {
        return Application.CreateClient();
    }

    public async ValueTask DisposeAsync()
    {
        await Application.DisposeAsync();
    }
}
