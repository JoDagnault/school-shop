using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Tests.SupplyLists.Fixtures.Key;

public static class SchoolFixture
{
    public static School ASchool() => new("A School");

    public static School AnotherSchool() => new("Another School");
}
