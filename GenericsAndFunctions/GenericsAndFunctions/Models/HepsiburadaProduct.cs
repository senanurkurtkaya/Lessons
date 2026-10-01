using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndFunctions.Models
{
    internal class HepsiburadaProduct
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal BasePrice { get; set; }

        public decimal Price { get; set; }

        public string StockCode { get; set; }

        public string Barcode { get; set; }

        public List<Discount> Discounts { get; } = [];

        public void IncreasePrice(decimal price)
        {
            BasePrice += price;
            Price += price;
        }

        public void DecreasePrice(decimal price)
        {
            BasePrice -= price;
            Price -= price;
        }

        public void AddDiscount(Discount discount)
        {
            if (discount.Type != DiscountType.Product)
            {
                throw new ArgumentException("Invalid discount type.");
            }

            Discounts.Add(discount);
        }

        public void GenerateBarcode(Action<HepsiburadaProduct> barcodeGenerator)
        {
            barcodeGenerator(this);
        }
    }

    internal static class HepsiburadaProductExtensions
    {
        public static decimal CalculateProfit(this HepsiburadaProduct product)
        {
            return product.Price - product.BasePrice;
        }
    }
}
