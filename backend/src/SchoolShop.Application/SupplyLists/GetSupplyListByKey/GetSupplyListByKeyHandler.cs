using MediatR;
using SchoolShop.Application.Exceptions;

namespace SchoolShop.Application.SupplyLists.GetSupplyListByKey;

public sealed class GetSupplyListByKeyHandler(ISupplyListRepository supplyLists)
    : IRequestHandler<GetSupplyListByKeyQuery, GetSupplyListResult>
{
    public async Task<GetSupplyListResult> Handle(
        GetSupplyListByKeyQuery request,
        CancellationToken cancellationToken)
    {
        var supplyList = await supplyLists.FindByKey(request.Key, cancellationToken)
            ?? throw new NotFoundException("Supply list was not found.");

        var items = supplyList.Items
            .Select(item => new GetSupplyListItemResult(item.Name, item.Quantity))
            .ToArray();

        return new GetSupplyListResult(items);
    }
}
