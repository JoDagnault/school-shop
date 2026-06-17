using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolShop.Application.SupplyLists;
using SchoolShop.Infrastructure.SupplyLists;

namespace SchoolShop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SchoolShop");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException("Connection string 'SchoolShop' is required.");
        }

        services.AddDbContext<SchoolShopDbContext>(options =>
            options.UseNpgsql(connectionString));

        services.AddScoped<ISupplyListRepository, EfSupplyListRepository>();

        return services;
    }
}
