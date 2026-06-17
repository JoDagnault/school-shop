using Microsoft.Extensions.DependencyInjection;
using SchoolShop.Application.SupplyLists.GetSupplyListByKey;

namespace SchoolShop.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblyContaining<GetSupplyListByKeyHandler>());

        return services;
    }
}
