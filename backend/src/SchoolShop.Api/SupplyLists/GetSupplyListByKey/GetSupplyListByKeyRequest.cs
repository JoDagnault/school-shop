using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Api.SupplyLists.GetSupplyListByKey;

public sealed class GetSupplyListByKeyRequest
{
    public string School { get; set; } = string.Empty;

    public string Grade { get; set; } = string.Empty;

    public uint AcademicYear { get; set; }

    public SupplyListKey ToKey()
    {
        return new SupplyListKey(
            new School(School),
            new Grade(Grade),
            new AcademicYear(AcademicYear));
    }
}
