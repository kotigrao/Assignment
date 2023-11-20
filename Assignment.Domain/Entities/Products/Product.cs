using System.ComponentModel.DataAnnotations;
using Vantlogix.Domain.Products;

namespace Assignment.Domain.Entities.Products
{
    public class Product
    {
        // Parameterless constructor for Entity Framework Core
        private Product() { }
        public Product(ProductId id, string name, Money price, StockUnit stockUnit) 
        {
            Id = id;
            Name = name;
            Price = price;
            StockUnit = stockUnit;
        }

        [Key]
        public ProductId Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public Money Price { get; private set; }
        public StockUnit StockUnit {  get; private set; }

        public void Update(string name, Money price, StockUnit stockUnit)
        {
            Name = name;
            Price = price;
            StockUnit = stockUnit;
        }
    }
}  