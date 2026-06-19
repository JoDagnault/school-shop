using SchoolShop.Domain.SupplyLists;
using SchoolShop.Tests.SupplyLists.Testing.Builders;
using SchoolShop.Tests.SupplyLists.Testing.Fixtures.Items;
using SchoolShop.Tests.SupplyLists.Testing.Fixtures.Key;

namespace SchoolShop.Tests.SupplyLists.Testing.Fixtures;

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
