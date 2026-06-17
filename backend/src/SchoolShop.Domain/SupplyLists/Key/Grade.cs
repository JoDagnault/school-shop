namespace SchoolShop.Domain.SupplyLists.Key;

public sealed record Grade
{
    public string Value { get; }

    public Grade(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Grade is required.", nameof(value));
        }

        Value = value;
    }
}
