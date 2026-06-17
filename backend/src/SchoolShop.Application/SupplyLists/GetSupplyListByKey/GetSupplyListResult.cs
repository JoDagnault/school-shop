using SchoolShop.Domain.SupplyLists.Items;

namespace SchoolShop.Application.SupplyLists.GetSupplyListByKey;

public sealed record GetSupplyListResult(IReadOnlyCollection<GetSupplyListItemResult> Items);

public sealed record GetSupplyListItemResult(SupplyListItemName Name, SupplyListItemQuantity Quantity);
