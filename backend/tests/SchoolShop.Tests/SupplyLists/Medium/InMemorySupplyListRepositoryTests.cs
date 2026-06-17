using SchoolShop.Application.SupplyLists;
using SchoolShop.Domain.SupplyLists;
using SchoolShop.Tests.SupplyLists.Fakes;

namespace SchoolShop.Tests.SupplyLists.Medium;

public sealed class InMemorySupplyListRepositoryTests : SupplyListRepositoryTests
{
    protected override ISupplyListRepository CreateRepositoryContaining(params SupplyList[] supplyLists)
    {
        return new InMemorySupplyListRepository(supplyLists);
    }
}
