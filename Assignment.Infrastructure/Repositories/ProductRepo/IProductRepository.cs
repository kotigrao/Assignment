using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Domain.Entities.Products;

namespace Assignment.Infrastructure.Repositories.ProductRepo
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(ProductId id);
        void Add(Product product);
        void Remove(Product product);
        void Update(Product product);
    }
}
