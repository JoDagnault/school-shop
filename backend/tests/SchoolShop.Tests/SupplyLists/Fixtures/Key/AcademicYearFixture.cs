using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Tests.SupplyLists.Fixtures.Key;

public static class AcademicYearFixture
{
    public static AcademicYear AnAcademicYear() => new(2019);

    public static AcademicYear AnotherAcademicYear() => new(2020);
}
