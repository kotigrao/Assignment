using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Infrastructure.Products.Create
{
    public record CreateProductCommand(
        string Name, 
        string StockUnit, 
        string Currency,
        decimal Amount): IRequest
    {
    }
}
