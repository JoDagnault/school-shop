using MediatR;
using SchoolShop.Domain.SupplyLists.Key;

namespace SchoolShop.Application.SupplyLists.GetSupplyListByKey;

public sealed record GetSupplyListByKeyQuery(SupplyListKey Key) : IRequest<GetSupplyListResult>;
