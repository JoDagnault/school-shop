using SchoolShop.Domain.SupplyLists;
using SchoolShop.Tests.SupplyLists.Builders;
using SchoolShop.Tests.SupplyLists.Fixtures.Items;
using SchoolShop.Tests.SupplyLists.Fixtures.Key;

namespace SchoolShop.Tests.SupplyLists.Fixtures;

public static class SupplyListFixture
{
    public static SupplyList ASupplyList()
    {
        return new SupplyListBuilder()
            .WithId(SupplyListIdFixture.ASupplyListId())
            .WithKey(SupplyListKeyFixture.ASupplyListKey())
            .WithItem(SupplyListItemFixture.ASupplyListItem())
            .Build();
    }

    public static SupplyList AnotherSupplyList()
    {
        return new SupplyListBuilder()
            .WithId(SupplyListIdFixture.AnotherSupplyListId())
            .WithKey(SupplyListKeyFixture.AnotherSupplyListKey())
            .WithItem(SupplyListItemFixture.AnotherSupplyListItem())
            .Build();
    }
}
