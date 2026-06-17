namespace SchoolShop.Domain.SupplyLists.Items;

public sealed record SupplyListItemQuantity
{
    public uint Quantity { get; }

    public SupplyListItemQuantity(uint quantity)
    {
        if (quantity == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero");
        }

        Quantity = quantity;
    }
}
