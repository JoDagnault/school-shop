using SchoolShop.Domain.SupplyLists.Items;

namespace SchoolShop.Tests.SupplyLists.Small.Items;

public class SupplyListItemQuantityTests
{
    [Fact]
    public void GivenZeroQuantity_WhenCreating_ShouldThrowArgumentOutOfRangeException()
    {
        SupplyListItemQuantity Act() => new SupplyListItemQuantity(0);

        Should.Throw<ArgumentOutOfRangeException>(Act);
    }
}
