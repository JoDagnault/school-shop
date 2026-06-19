using SchoolShop.Application.SupplyLists;
using SchoolShop.Domain.SupplyLists;
using SchoolShop.Tests.SupplyLists.Testing.Fakes;
using SchoolShop.Tests.SupplyLists.Contracts;

namespace SchoolShop.Tests.SupplyLists.Small.Infrastructure.Repositories;

[Trait("Size", "Small")]
public sealed class InMemorySupplyListRepositoryContractTests : SupplyListRepositoryContractTests
{
    protected override ISupplyListRepository CreateRepositoryContaining(params SupplyList[] supplyLists)
    {
        return new InMemorySupplyListRepository(supplyLists);
    }
}
