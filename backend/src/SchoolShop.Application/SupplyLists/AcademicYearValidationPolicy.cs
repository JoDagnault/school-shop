namespace SchoolShop.Application.SupplyLists;

public static class AcademicYearValidationPolicy
{
    public const int MinimumSupportedStartYear = 2025;
    public const int MaximumSupportedStartYear = 2030;
    public const string SupportedStartYearRangeErrorMessage = "Academic year must be between {1} and {2}.";
}
