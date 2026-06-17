using SchoolShop.Application.SupplyLists;
using SchoolShop.Domain.SupplyLists;
using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Tests.SupplyLists.Fakes;

public sealed class InMemorySupplyListRepository : ISupplyListRepository
{
    private readonly IReadOnlyCollection<SupplyList> _supplyLists;

    public InMemorySupplyListRepository(params SupplyList[] supplyLists)
    {
        _supplyLists = supplyLists;
    }

    public Task<SupplyList?> FindByKey(SupplyListKey key, CancellationToken cancellationToken)
    {
        var supplyList = _supplyLists.SingleOrDefault(supplyList => supplyList.Key == key);

        return Task.FromResult(supplyList);
    }
}
