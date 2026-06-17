using MediatR;
using SchoolShop.Application.SupplyLists.GetSupplyListByKey;
using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Api.SupplyLists.GetSupplyListByKey;

public static class GetSupplyListByKeyEndpoint
{
    public static IEndpointRouteBuilder MapGetSupplyListByKeyEndpoint(this IEndpointRouteBuilder endpoints)
    {
        endpoints
            .MapGet("/supply-lists", Handle)
            .WithName("GetSupplyListByKey");

        return endpoints;
    }

    private static async Task<IResult> Handle(
        [AsParameters] GetSupplyListByKeyRequest request,
        ISender sender,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(new GetSupplyListByKeyQuery(request.ToKey()), cancellationToken);

        return Results.Ok(GetSupplyListByKeyResponse.From(result));
    }
}
