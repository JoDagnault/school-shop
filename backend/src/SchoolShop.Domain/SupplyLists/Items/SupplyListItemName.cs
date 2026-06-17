namespace SchoolShop.Domain.SupplyLists.Items;

public sealed record SupplyListItemName
{
    public string Name { get; }

    public SupplyListItemName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Supply list item name is required.", nameof(name));
        }

        Name = name;
    }
}
