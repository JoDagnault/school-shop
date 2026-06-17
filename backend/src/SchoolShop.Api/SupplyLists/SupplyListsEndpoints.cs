using SchoolShop.Api.SupplyLists.GetSupplyListByKey;

namespace SchoolShop.Api.SupplyLists;

public static class SupplyListsEndpoints
{
    public static IEndpointRouteBuilder MapSupplyListsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGetSupplyListByKeyEndpoint();

        return endpoints;
    }
}
