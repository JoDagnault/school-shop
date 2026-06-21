using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Tests.SupplyLists.Small.Domain.Key;

[Trait("Size", "Small")]
public class AcademicYearTests
{
    [Theory]
    [InlineData(2021, 2022)]
    [InlineData(0, 1)]
    [InlineData(9999, 10000)]
    public void GivenAStartYear_WhenCreating_ShouldSetEndYearToTheNextYear(uint startYear, uint expectedEndYear)
    {
        var academicYear = new AcademicYear(startYear);

        academicYear.EndYear.ShouldBe(expectedEndYear);
    }

    [Fact]
    public void GivenAStartYearAboveMaximum_WhenCreating_ShouldThrowArgumentOutOfRangeException()
    {
        AcademicYear Act() => new AcademicYear(uint.MaxValue);

        Should.Throw<ArgumentOutOfRangeException>(Act);
    }

    [Fact]
    public void GivenANegativeStartYear_WhenCreating_ShouldThrowArgumentOutOfRangeException()
    {
        AcademicYear Act() => new AcademicYear(-1);

        Should.Throw<ArgumentOutOfRangeException>(Act);
    }
}
