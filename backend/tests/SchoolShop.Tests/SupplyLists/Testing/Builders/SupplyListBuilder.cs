using SchoolShop.Domain.SupplyLists;
using SchoolShop.Domain.SupplyLists.Items;
using SchoolShop.Domain.SupplyLists.Key;
using SchoolShop.Tests.SupplyLists.Testing.Fixtures;
using SchoolShop.Tests.SupplyLists.Testing.Fixtures.Key;

namespace SchoolShop.Tests.SupplyLists.Testing.Builders;

public class SupplyListBuilder
{
    private SupplyListId _id = SupplyListIdFixture.ASupplyListId();
    private School _school = SchoolFixture.ASchool();
    private Grade _grade = GradeFixture.AGrade();
    private AcademicYear _academicYear = AcademicYearFixture.AnAcademicYear();
    private List<SupplyListItem> _supplyListItems = [];

    public SupplyList Build()
    {
        var key = new SupplyListKey(_school, _grade, _academicYear);

        return new SupplyList(_id, key, _supplyListItems);
    }

    public SupplyListBuilder WithId(SupplyListId id)
    {
        _id = id;
        return this;
    }

    public SupplyListBuilder WithKey(SupplyListKey key)
    {
        _school = key.School;
        _grade = key.Grade;
        _academicYear = key.AcademicYear;
        return this;
    }

    public SupplyListBuilder WithItem(string name, uint quantity)
    {
        return WithItem(new SupplyListItemName(name), new SupplyListItemQuantity(quantity));
    }

    public SupplyListBuilder WithItem(SupplyListItemName name, SupplyListItemQuantity quantity)
    {
        return WithItem(new SupplyListItem(name, quantity));
    }

    public SupplyListBuilder WithItem(SupplyListItem item)
    {
        _supplyListItems.Add(item);
        return this;
    }
}
