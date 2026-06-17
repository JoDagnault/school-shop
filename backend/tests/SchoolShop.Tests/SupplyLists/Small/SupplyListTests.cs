using SchoolShop.Domain.SupplyLists;
using SchoolShop.Tests.SupplyLists.Builders;
using SchoolShop.Tests.SupplyLists.Fixtures.Items;

namespace SchoolShop.Tests.SupplyLists.Small;

public class SupplyListTests
{
    [Fact]
    public void GivenDuplicateSupplyListItem_WhenCreating_ShouldThrowArgumentException()
    {
        var duplicateItemName = SupplyListItemNameFixture.ASupplyListItemName();

        SupplyList Act() => new SupplyListBuilder()
            .WithItem(duplicateItemName, SupplyListItemQuantityFixture.ASupplyListItemQuantity())
            .WithItem(duplicateItemName, SupplyListItemQuantityFixture.AnotherSupplyListItemQuantity())
            .Build();

        Should.Throw<ArgumentException>(Act);
    }
}
