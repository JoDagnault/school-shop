using SchoolShop.Domain.SupplyLists.Items;
using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Domain.SupplyLists;

public class SupplyList
{
    private readonly SupplyListId _id;
    private readonly SupplyListKey _key;
    private readonly Dictionary<SupplyListItemName, SupplyListItemQuantity> _items;

    public SupplyListId Id => _id;
    public SupplyListKey Key => _key;
    public IEnumerable<SupplyListItem> Items => _items.Select(item => new SupplyListItem(item.Key, item.Value));

    public SupplyList(SupplyListId id, SupplyListKey key, IEnumerable<SupplyListItem> items)
    {
        _id = id;
        _key = key;

        _items = new Dictionary<SupplyListItemName, SupplyListItemQuantity>();

        foreach (var supplyListItem in items)
        {
            if (!_items.TryAdd(supplyListItem.Name, supplyListItem.Quantity))
            {
                throw new ArgumentException($"Supply list item {supplyListItem.Name} already exists");
            }
        }
    }
}
