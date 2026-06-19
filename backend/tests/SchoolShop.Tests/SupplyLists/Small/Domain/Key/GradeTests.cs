using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Tests.SupplyLists.Small.Domain.Key;

[Trait("Size", "Small")]
public class GradeTests
{
    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("     ")]
    public void GivenAnInvalidGrade_WhenCreating_ShouldThrowArgumentException(string grade)
    {
        Grade Act() => new Grade(grade);

        Should.Throw<ArgumentException>(Act);
    }
}
