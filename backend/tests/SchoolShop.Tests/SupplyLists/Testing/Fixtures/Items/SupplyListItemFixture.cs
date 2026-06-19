using SchoolShop.Domain.SupplyLists.Items;

namespace SchoolShop.Tests.SupplyLists.Testing.Fixtures.Items;

public static class SupplyListItemFixture
{
    public static SupplyListItem ASupplyListItem()
    {
        return new SupplyListItem(
            SupplyListItemNameFixture.ASupplyListItemName(),
            SupplyListItemQuantityFixture.ASupplyListItemQuantity());
    }

    public static SupplyListItem AnotherSupplyListItem()
    {
        return new SupplyListItem(
            SupplyListItemNameFixture.AnotherSupplyListItemName(),
            SupplyListItemQuantityFixture.AnotherSupplyListItemQuantity());
    }
}
