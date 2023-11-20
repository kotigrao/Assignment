using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Domain.Products;
using Assignment.Domain.Entities.Products;
using Assignment.Infrastructure.Data;
using Assignment.Infrastructure.DbContexts;
//using Assignment.Persistance;

namespace Assignment.Infrastructure.Products.Get
{
    internal sealed class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductResponse>
    {
        private readonly ApplicationDbContext _context;
        public GetProductQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _context
                .Products
                .Where(p => p.Id == request.ProductId)
                .Select(p => new ProductResponse(
                    p.Id.Value,
                    p.Name,
                    p.StockUnit.Value,
                    p.Price.Currency,
                    p.Price.Amount))
                .FirstOrDefaultAsync(cancellationToken);
            if (product is null)
            {
                throw new ProductNotFoundException(request.ProductId);
            }
            return product;
        }
    }
}
