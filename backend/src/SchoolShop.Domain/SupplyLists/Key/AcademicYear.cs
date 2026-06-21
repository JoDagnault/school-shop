namespace SchoolShop.Domain.SupplyLists.Key;

public record AcademicYear
{
    public uint StartYear { get; }
    public uint EndYear { get; }

    public AcademicYear(int startYear)
    {
        if (startYear < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(startYear), "Academic year start year must be greater than or equal to 0.");
        }

        StartYear = (uint)startYear;
        EndYear = StartYear + 1;
    }

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
