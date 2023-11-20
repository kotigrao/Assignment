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
    internal sealed class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductsResponse>>
    {
        private readonly ApplicationDbContext _context;
        public GetProductsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductsResponse>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context
                .Products
                .Select(p => new ProductsResponse(
                    p.Id.Value,
                    p.Name,
                    p.StockUnit.Value,
                    p.Price.Currency,
                    p.Price.Amount))
                .ToListAsync(cancellationToken);
            if (products is null)
            {
                throw new ProductNotFoundException();
            }
            return products;
        }
    }
}
