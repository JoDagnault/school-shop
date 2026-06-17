using SchoolShop.Domain.SupplyLists.Items;

namespace SchoolShop.Tests.SupplyLists.Fixtures.Items;

public static class SupplyListItemNameFixture
{
    public static SupplyListItemName ASupplyListItemName() => new("Blue Pen");

    public static SupplyListItemName AnotherSupplyListItemName() => new("Glue Stick");
}
