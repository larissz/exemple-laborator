using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tema1.Domain
{
    public record ValidatedProduct(ProductId ProductId, Quantity Quantity);
}
