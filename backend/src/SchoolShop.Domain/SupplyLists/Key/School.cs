namespace SchoolShop.Domain.SupplyLists.Key;

public sealed record School
{
    public string Name { get; }

    public School(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("School name is required.", nameof(name));
        }

        Name = name;
    }
}
