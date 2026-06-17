using SchoolShop.Application.Common.Exceptions;
using SchoolShop.Application.SupplyLists.GetSupplyListByKey;
using SchoolShop.Domain.SupplyLists.Items;
using SchoolShop.Tests.SupplyLists.Builders;
using SchoolShop.Tests.SupplyLists.Fakes;
using SchoolShop.Tests.SupplyLists.Fixtures;
using SchoolShop.Tests.SupplyLists.Fixtures.Key;

namespace SchoolShop.Tests.SupplyLists.Medium.GetSupplyListByKey;

public class GetSupplyListByKeyHandlerTests
{
    [Fact]
    public async Task GivenMultipleSupplyLists_WhenHandlingGetSupplyListByKeyQuery_ShouldReturnMatchingSupplyListItems()
    {
        const string expectedItemName = "Graphite Pencil";
        const uint expectedItemQuantity = 12;
        var expectedSupplyList = new SupplyListBuilder()
            .WithItem(expectedItemName, expectedItemQuantity)
            .Build();
        var repository = new InMemorySupplyListRepository(expectedSupplyList, SupplyListFixture.AnotherSupplyList());
        var handler = new GetSupplyListByKeyHandler(repository);
        var query = new GetSupplyListByKeyQuery(expectedSupplyList.Key);

        var result = await handler.Handle(query, CancellationToken.None);

        result.Items.ShouldBe([
            new GetSupplyListItemResult(
                new SupplyListItemName(expectedItemName),
                new SupplyListItemQuantity(expectedItemQuantity))
        ]);
    }

    [Fact]
    public async Task GivenMissingSupplyList_WhenHandlingGetSupplyListByKeyQuery_ShouldThrowNotFoundException()
    {
        var missingSupplyListKey = SupplyListKeyFixture.ASupplyListKey();
        var repository = new InMemorySupplyListRepository();
        var handler = new GetSupplyListByKeyHandler(repository);
        var query = new GetSupplyListByKeyQuery(missingSupplyListKey);

        async Task Act() => await handler.Handle(query, CancellationToken.None);

        await Should.ThrowAsync<NotFoundException>(Act);
    }
}
