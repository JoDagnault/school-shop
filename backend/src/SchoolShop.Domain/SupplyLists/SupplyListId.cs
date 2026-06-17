namespace SchoolShop.Domain.SupplyLists;

public readonly record struct SupplyListId(Guid Value)
{
    public static SupplyListId New() => new(Guid.NewGuid());
}
