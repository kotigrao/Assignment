using Assignment.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Entities.Products
{
    public interface IProductRepository
    {
        Task<List<Product?>> GetAsync();
        Task<Product?> GetByIdAsync(ProductId id);
        void Add(Product product);
        void Remove(Product product);
        void Update(Product product);
    }
}
