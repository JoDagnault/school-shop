using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Tests.SupplyLists.Fixtures.Key;

public static class GradeFixture
{
    public static Grade AGrade() => new("Grade 4");

    public static Grade AnotherGrade() => new("Grade 5");
}
