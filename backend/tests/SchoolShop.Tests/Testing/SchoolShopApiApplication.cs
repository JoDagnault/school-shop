using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace SchoolShop.Tests.Testing;

public sealed class SchoolShopApiApplication : WebApplicationFactory<Program>
{
    private readonly string _connectionString;

    public SchoolShopApiApplication(string connectionString)
    {
        _connectionString = connectionString;
    }

    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureHostConfiguration(configuration =>
        {
            configuration.AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["ConnectionStrings:SchoolShop"] = _connectionString
            });
        });

        return base.CreateHost(builder);
    }
}
