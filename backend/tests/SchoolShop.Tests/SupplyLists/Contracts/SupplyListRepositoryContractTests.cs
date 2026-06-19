using SchoolShop.Application.SupplyLists;
using SchoolShop.Domain.SupplyLists;
using SchoolShop.Tests.SupplyLists.Testing.Assertions;
using SchoolShop.Tests.SupplyLists.Testing.Fixtures;
using SchoolShop.Tests.SupplyLists.Testing.Fixtures.Key;

namespace SchoolShop.Tests.SupplyLists.Contracts;

public abstract class SupplyListRepositoryContractTests
{
    [Fact]
    public async Task GivenMultipleSupplyLists_WhenFindingByKey_ShouldReturnMatchingSupplyList()
    {
        var expectedSupplyList = SupplyListFixture.ASupplyList();
        var repository = CreateRepositoryContaining(
            expectedSupplyList,
            SupplyListFixture.AnotherSupplyList());

        var supplyList = await repository.FindByKey(expectedSupplyList.Key, CancellationToken.None);

        supplyList.ShouldBeEqualTo(expectedSupplyList);
    }

    [Fact]
    public async Task GivenMissingSupplyList_WhenFindingByKey_ShouldReturnNull()
    {
        var repository = CreateRepositoryContaining();
        var missingSupplyListKey = SupplyListKeyFixture.ASupplyListKey();

        var supplyList = await repository.FindByKey(missingSupplyListKey, CancellationToken.None);

        supplyList.ShouldBeNull();
    }

    protected abstract ISupplyListRepository CreateRepositoryContaining(params SupplyList[] supplyLists);
}
