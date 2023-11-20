using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Domain.Products;
using Assignment.Domain.Entities.Products;

namespace Assignment.Infrastructure.Products.Get
{
    public record GetProductQuery(ProductId ProductId): IRequest<ProductResponse>;
    public record ProductResponse(
        Guid Id,
        string Name,
        string StockUnit,
        string Currency,
        decimal Amount
    );
}
