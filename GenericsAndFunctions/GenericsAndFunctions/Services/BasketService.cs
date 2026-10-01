using GenericsAndFunctions.Models;

namespace GenericsAndFunctions.Services
{
    internal class BasketService<TProduct>
    {
        public List<TProduct> Items { get; set; } = [];

        public List<Discount> Discounts { get; } = [];

        public void AddDiscount(Discount discount)
        {
            if (discount.Type != DiscountType.Basket)
            {
                throw new ArgumentException("Invalid discount type");
            }

            Discounts.Add(discount);
        }

        public decimal GetTotalPrice(Func<List<TProduct>, List<Discount>, decimal> calculate)
        {
            return calculate(Items, Discounts);
        }
    }
}
