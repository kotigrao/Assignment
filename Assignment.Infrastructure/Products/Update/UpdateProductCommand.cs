using Assignment.Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vantlogix.Domain.Products;

namespace Vantlogix.Infrastructure.Products.Update
{
    public record UpdateProductCommand(
        ProductId ProductId,
        string Name,
        string StockUnit,
        string Currency,
        decimal Amount): IRequest;
    public record UpdateProductRequest(
        string Name,
        string StockUnit,
        string Currency,
        decimal Amount);
}
