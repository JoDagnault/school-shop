using SchoolShop.Domain.SupplyLists.Items;

namespace SchoolShop.Tests.SupplyLists.Small.Domain.Items;

[Trait("Size", "Small")]
public class SupplyListItemQuantityTests
{
    [Fact]
    public void GivenZeroQuantity_WhenCreating_ShouldThrowArgumentOutOfRangeException()
    {
        SupplyListItemQuantity Act() => new SupplyListItemQuantity(0);

        Should.Throw<ArgumentOutOfRangeException>(Act);
    }
}
