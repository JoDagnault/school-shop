using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Tests.SupplyLists.Small.Key;

public class SchoolTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("     ")]
    public void GivenAnInvalidSchoolName_WhenCreating_ShouldThrowArgumentException(string schoolName)
    {
        School Act() => new School(schoolName);

        Should.Throw<ArgumentException>(Act);
    }
}
