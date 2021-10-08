using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1.Domain
{
    public record Quantity
    {
        public decimal Value { get; }

        public Quantity(decimal value)
        {
            if (value > 0 && value <= 20)
            {
                Value = value;
            }
            else
            {
                throw new InvalidQuantityException($"{value:0.##} is an invalid grade value.");
            }
        }

        public override string ToString()
        {
            return $"{Value:0.##}";
        }
    }
}
