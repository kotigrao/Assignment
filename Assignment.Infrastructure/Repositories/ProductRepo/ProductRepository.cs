using Assignment.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Infrastructure.Repositories.ProductRepo
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new List<Product>();

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public void Add(Product product)
        {
            // Assuming you have some logic to generate a unique ID.
            //product.Id = new ProductId(Guid.NewGuid());
            _products.Add(product);
        }

        public void Update(Product product)
        {
            // Assuming you have some logic to update the product.
            var existingProduct = _products.FirstOrDefault(p => p.Id == product.Id);

            if (existingProduct != null)
            {
                //existingProduct.Update = product.Name;
                // Update other properties...
            }
        }
        public void Delete(Product product)
        {
            _products.Remove(product);
        }

        public void Remove(Product product)
        {
            throw new NotImplementedException();
        }

        Task<Product?> IProductRepository.GetByIdAsync(ProductId id)
        {
            throw new NotImplementedException();
        }
    }
}
