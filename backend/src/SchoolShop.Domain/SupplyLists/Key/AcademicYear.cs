namespace SchoolShop.Domain.SupplyLists.Key;

public record AcademicYear
{
    public uint StartYear { get; }
    public uint EndYear { get; }

    public AcademicYear(uint startYear)
    {
        if (startYear == uint.MaxValue)
        {
            throw new ArgumentOutOfRangeException(nameof(startYear), $"Academic year start year must be less than {int.MaxValue}");
        }

        StartYear = startYear;
        EndYear = startYear + 1;
    }

    public override string ToString() => $"{StartYear}-{EndYear}";
}
