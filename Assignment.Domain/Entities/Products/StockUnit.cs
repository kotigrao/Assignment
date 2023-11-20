using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Entities.Products
{
    public record StockUnit
    {
        private const int DefaultLength = 10;
        private StockUnit(string value) => Value = value;
        public string Value { get; init; }
        public static StockUnit? Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }
            if(value.Length != DefaultLength)
            {
                return null;
            }
            return new StockUnit(value);
        }
    }
}
