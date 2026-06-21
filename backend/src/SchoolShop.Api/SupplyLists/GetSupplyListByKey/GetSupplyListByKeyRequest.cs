using System.ComponentModel.DataAnnotations;
using SchoolShop.Application.SupplyLists;
using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Api.SupplyLists.GetSupplyListByKey;

public sealed class GetSupplyListByKeyRequest
{
    [Required]
    public string? School { get; init; }

    [Required]
    public string? Grade { get; init; }

    [Required]
    [Range(
        AcademicYearValidationPolicy.MinimumSupportedStartYear,
        AcademicYearValidationPolicy.MaximumSupportedStartYear,
        ErrorMessage = AcademicYearValidationPolicy.SupportedStartYearRangeErrorMessage)]
    public int? AcademicYear { get; init; }

    internal SupplyListKey ToKey()
    {
        return new SupplyListKey(
            new School(School!),
            new Grade(Grade!),
            new AcademicYear(AcademicYear!.Value));
    }
}
