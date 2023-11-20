using Assignment.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Products
{
    public sealed class ProductNotFoundException: Exception
    {
        public ProductNotFoundException(ProductId id) : base($"The Product with the ID ={id.Value} was not found")
        {

        }
        public ProductNotFoundException() : base($"The Products was not found")
        {

        }
    }
}
