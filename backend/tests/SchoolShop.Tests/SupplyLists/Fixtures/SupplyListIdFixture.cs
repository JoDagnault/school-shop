using SchoolShop.Domain.SupplyLists;

namespace SchoolShop.Tests.SupplyLists.Fixtures;

public static class SupplyListIdFixture
{
    public static SupplyListId ASupplyListId() =>
        new(Guid.Parse("11111111-1111-1111-1111-111111111111"));

    public static SupplyListId AnotherSupplyListId() =>
        new(Guid.Parse("22222222-2222-2222-2222-222222222222"));
}
