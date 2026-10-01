using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndFunctions.Models
{
    internal class Discount
    {
        public DiscountType Type { get; set; }

        public string Name { get; set; }

        public decimal Amount { get; set; }
    }

    internal enum DiscountType
    {
        Product,
        Basket,
    }
}
