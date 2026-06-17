using SchoolShop.Domain.SupplyLists.Items;

namespace SchoolShop.Infrastructure.SupplyLists;

public sealed class SupplyListItemEntity
{
    public required Guid Id { get; set; }
    public required Guid SupplyListId { get; set; }
    public required string Name { get; set; }
    public required uint Quantity { get; set; }

    public static SupplyListItemEntity From(SupplyListItem item, Guid supplyListId)
    {
        return new SupplyListItemEntity
        {
            Id = Guid.NewGuid(),
            SupplyListId = supplyListId,
            Name = item.Name.Name,
            Quantity = item.Quantity.Quantity
        };
    }

    public SupplyListItem ToDomain()
    {
        return new SupplyListItem(
            new SupplyListItemName(Name),
            new SupplyListItemQuantity(Quantity));
    }
}
