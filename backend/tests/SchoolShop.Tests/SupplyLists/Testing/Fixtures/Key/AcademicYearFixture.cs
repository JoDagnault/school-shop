using SchoolShop.Application.SupplyLists;
using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Tests.SupplyLists.Testing.Fixtures.Key;

public static class AcademicYearFixture
{
    public static AcademicYear AnAcademicYear() => new(AcademicYearValidationPolicy.MinimumSupportedStartYear);

    public static AcademicYear AnotherAcademicYear() => new(AcademicYearValidationPolicy.MinimumSupportedStartYear + 1);
}
