using SchoolShop.Domain.SupplyLists;
using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Application.SupplyLists;

public interface ISupplyListRepository
{
    Task<SupplyList?> FindByKey(SupplyListKey key, CancellationToken cancellationToken);
}
