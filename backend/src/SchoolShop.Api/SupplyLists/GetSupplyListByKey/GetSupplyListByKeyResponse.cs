using SchoolShop.Application.SupplyLists.GetSupplyListByKey;

namespace SchoolShop.Api.SupplyLists.GetSupplyListByKey;

public sealed record GetSupplyListByKeyResponse(IReadOnlyCollection<GetSupplyListByKeyItemResponse> Items)
{
    public static GetSupplyListByKeyResponse From(GetSupplyListResult result)
    {
        var items = result.Items
            .Select(GetSupplyListByKeyItemResponse.From)
            .ToArray();

        return new GetSupplyListByKeyResponse(items);
    }
}

public sealed record GetSupplyListByKeyItemResponse(string Name, uint Quantity)
{
    public static GetSupplyListByKeyItemResponse From(GetSupplyListItemResult item)
    {
        return new GetSupplyListByKeyItemResponse(
            item.Name.Name,
            item.Quantity.Quantity);
    }
}
