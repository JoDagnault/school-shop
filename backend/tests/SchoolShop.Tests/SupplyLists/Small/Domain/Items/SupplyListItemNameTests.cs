using SchoolShop.Domain.SupplyLists.Items;

namespace SchoolShop.Tests.SupplyLists.Small.Domain.Items;

[Trait("Size", "Small")]
public class SupplyListItemNameTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("     ")]
    public void GivenAnInvalidSupplyListItemName_WhenCreating_ShouldThrowArgumentException(string itemName)
    {
        SupplyListItemName Act() => new SupplyListItemName(itemName);

        Should.Throw<ArgumentException>(Act);
    }
}
