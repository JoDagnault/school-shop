using Microsoft.EntityFrameworkCore;
using SchoolShop.Application.SupplyLists;
using SchoolShop.Domain.SupplyLists;
using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Infrastructure.SupplyLists;

public sealed class EfSupplyListRepository(SchoolShopDbContext dbContext) : ISupplyListRepository
{
    private readonly SchoolShopDbContext _dbContext = dbContext;

    public async Task<SupplyList?> FindByKey(SupplyListKey key, CancellationToken cancellationToken)
    {
        var supplyList = await _dbContext.SupplyLists
            .Include(supplyList => supplyList.Items)
            .AsNoTracking()
            .SingleOrDefaultAsync(
                supplyList =>
                    supplyList.SchoolName == key.School.Name &&
                    supplyList.Grade == key.Grade.Value &&
                    supplyList.AcademicYearStart == key.AcademicYear.StartYear,
                cancellationToken);

        return supplyList?.ToDomain();
    }
}
