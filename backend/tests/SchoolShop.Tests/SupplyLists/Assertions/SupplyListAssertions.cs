using SchoolShop.Domain.SupplyLists;

namespace SchoolShop.Tests.SupplyLists.Assertions;

public static class SupplyListAssertions
{
    public static void ShouldBeEqualTo(this SupplyList? actual, SupplyList expected)
    {
        actual.ShouldNotBeNull();
        actual!.Id.ShouldBe(expected.Id);
        actual.Key.ShouldBe(expected.Key);
        actual.Items.ShouldBe(expected.Items, ignoreOrder: true);
    }
}
