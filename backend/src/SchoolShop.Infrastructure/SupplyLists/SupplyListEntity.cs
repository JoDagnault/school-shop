using SchoolShop.Domain.SupplyLists;
using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Infrastructure.SupplyLists;

public sealed class SupplyListEntity
{
    public required Guid Id { get; set; }
    public required string SchoolName { get; set; }
    public required string Grade { get; set; }
    public required uint AcademicYearStart { get; set; }
    public List<SupplyListItemEntity> Items { get; set; } = [];

    public static SupplyListEntity From(SupplyList supplyList)
    {
        var key = supplyList.Key;
        var supplyListId = supplyList.Id.Value;

        return new SupplyListEntity
        {
            Id = supplyListId,
            SchoolName = key.School.Name,
            Grade = key.Grade.Value,
            AcademicYearStart = key.AcademicYear.StartYear,
            Items = supplyList.Items
                .Select(item => SupplyListItemEntity.From(item, supplyListId))
                .ToList()
        };
    }

    public SupplyList ToDomain()
    {
        var key = new SupplyListKey(
            new School(SchoolName),
            new Grade(Grade),
            new AcademicYear(AcademicYearStart));

        return new SupplyList(
            new SupplyListId(Id),
            key,
            Items.Select(item => item.ToDomain()));
    }
}
