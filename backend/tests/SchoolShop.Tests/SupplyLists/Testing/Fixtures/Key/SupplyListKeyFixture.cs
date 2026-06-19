using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Tests.SupplyLists.Testing.Fixtures.Key;

public static class SupplyListKeyFixture
{
    public static SupplyListKey ASupplyListKey()
    {
        return new SupplyListKey(
            SchoolFixture.ASchool(),
            GradeFixture.AGrade(),
            AcademicYearFixture.AnAcademicYear());
    }

    public static SupplyListKey AnotherSupplyListKey()
    {
        return new SupplyListKey(
            SchoolFixture.AnotherSchool(),
            GradeFixture.AnotherGrade(),
            AcademicYearFixture.AnotherAcademicYear());
    }
}
