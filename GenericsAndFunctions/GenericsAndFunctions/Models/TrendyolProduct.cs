using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndFunctions.Models
{
    internal class TrendyolProduct
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal BasePrice { get; set; }

        public decimal Price { get; set; }

        public int TaxRate { get; set; }

        public string SKU { get; set; }

        public List<Discount> Discounts { get; } = [];

        public void AddDiscount(Discount discount)
        {
            if (discount.Type != DiscountType.Product)
            {
                throw new ArgumentException("Invalid discount type.");
            }

            Discounts.Add(discount);
        }
    }

    internal static class TrendyolProductExtensions
    {
        public static decimal CalculateProfit(this TrendyolProduct product)
        {
            return product.Price - product.BasePrice;
        }
    }
}
