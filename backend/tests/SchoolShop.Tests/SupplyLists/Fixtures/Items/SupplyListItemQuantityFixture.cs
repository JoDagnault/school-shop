using SchoolShop.Domain.SupplyLists.Items;

namespace SchoolShop.Tests.SupplyLists.Fixtures.Items;

public static class SupplyListItemQuantityFixture
{
    public static SupplyListItemQuantity ASupplyListItemQuantity() => new(3);

    public static SupplyListItemQuantity AnotherSupplyListItemQuantity() => new(5);
}
