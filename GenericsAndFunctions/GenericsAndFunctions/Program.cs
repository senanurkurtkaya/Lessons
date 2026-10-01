using GenericsAndFunctions.Models;
using GenericsAndFunctions.Services;

namespace GenericsAndFunctions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> stringList = new List<string>();
            List<int> intList = new List<int>();

            stringList.Add("Sena");
            stringList.Add("Selman");

            intList.Add(12);
            intList.Add(18);


            ProductSyncService<TrendyolProduct> trendyolProductSyncService = new ProductSyncService<TrendyolProduct>();

            var trendyolProducts = new List<TrendyolProduct>
            {
                new TrendyolProduct
                {
                    Id = 1,
                    Name = "Örnek Poster 1",
                    Description = "Örnek ürün açıklaması 1",
                    BasePrice = 500m,
                    Price = 600m,
                    TaxRate = 20,
                    SKU = "POSTER-001"
                },
                new TrendyolProduct
                {
                    Id = 2,
                    Name = "Örnek Poster 2",
                    Description = "Örnek ürün açıklaması 2",
                    BasePrice = 700m,
                    Price = 840m,
                    TaxRate = 20,
                    SKU = "POSTER-002"
                }
            };

            trendyolProductSyncService.Sync(trendyolProducts);

            var trendyolProduct = trendyolProducts.First();

            ProductSyncService<HepsiburadaProduct> hepsiBuradaSyncService = new ProductSyncService<HepsiburadaProduct>();



            var hepsiburadaProducts = new List<HepsiburadaProduct>
            {
                new HepsiburadaProduct
                {
                    Id = 1,
                    Name = "Örnek Poster 1",
                    Description = "Örnek ürün açıklaması 1",
                    BasePrice = 500m,
                    Price = 600m,
                    StockCode = "HB-POSTER-001",
                    Barcode = "8690000000001"
                },
                new HepsiburadaProduct
                {
                    Id = 2,
                    Name = "Örnek Poster 2",
                    Description = "Örnek ürün açıklaması 2",
                    BasePrice = 700m,
                    Price = 840m,
                    StockCode = "HB-POSTER-002",
                    Barcode = "8690000000002"
                }
            };

            hepsiBuradaSyncService.Sync(hepsiburadaProducts);

            AnotherSyncService anotherSyncService = new AnotherSyncService();

            anotherSyncService.Sync(hepsiburadaProducts);

            var elasticProducts = new List<ElasticProductModel>();

            anotherSyncService.SyncWithElastic(hepsiburadaProducts, elasticProducts);

            anotherSyncService.SyncWithElastic(hepsiburadaProducts, hepsiburadaProducts, elasticProducts);

            var hepsiburadaProduct = hepsiburadaProducts.First();

            var elasticProduct = anotherSyncService.ConvertToElastic<HepsiburadaProduct, ElasticProductModel>(hepsiburadaProduct);

            var profit = hepsiburadaProduct.CalculateProfit();


            var basketService = new BasketService<HepsiburadaProduct>();

            var productDiscount = new Discount
            {
                Amount = 5,
                Name = "Üründe indirim",
                Type = DiscountType.Product,
            };

            hepsiburadaProduct.AddDiscount(productDiscount);

            basketService.Items.Add(hepsiburadaProduct);

            var basketDiscount = new Discount
            {
                Amount = 10,
                Name = "Sepette indirim",
                Type = DiscountType.Basket,
            };

            basketService.AddDiscount(basketDiscount);

            // (extension) [dönüşTipi] [aitOlduğuSınıf].[fonksiyonAdı](...)
            // ... [tipi] [parametre]
            // ... [tipi] [parametre], [tipi] [parametre], [tipi] [parametre]


            var totalBasketPrice = basketService.GetTotalPrice((items, basketDiscounts) =>
            {
                var totalItemPrice = 0M;
                for (var i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    totalItemPrice += item.Price;
                    if (item.Discounts.Count > 0)
                    {
                        for (var j = 0; j < item.Discounts.Count; j++)
                        {
                            var itemDiscount = item.Discounts[j];
                            totalItemPrice -= itemDiscount.Amount;
                        }
                    }
                }

                var totalPrice = totalItemPrice;
                if (basketDiscounts.Count > 0)
                {
                    for (var i = 0; i < basketDiscounts.Count; i++)
                    {
                        var basketDiscount = basketDiscounts[i];
                        totalPrice -= basketDiscount.Amount;
                    }
                }

                return totalPrice;
            });


            //IEnumerable<HepsiburadaProduct> urunler = new List<HepsiburadaProduct>();
            var productPrices = hepsiburadaProducts.Select<HepsiburadaProduct, decimal>(product => product.Price);

            var productBasePrices = hepsiburadaProducts.Select<HepsiburadaProduct, decimal>(product => product.BasePrice);

            var productProfits = hepsiburadaProducts.Select<HepsiburadaProduct, decimal>(product => product.CalculateProfit());

            var productNameAndPrices = hepsiburadaProducts.Select(product => new ProductNameWithPrice
            {
                Name = product.Name,
                Price = product.Price
            });

            var productPricesWithDiscounts = hepsiburadaProducts
                .Select(product => product.Price - product.Discounts.Sum(discount => discount.Amount));

            hepsiburadaProduct.GenerateBarcode(product =>
            {
                product.Barcode = $"{product.Name}-{DateTime.Now.ToString("yyyyMMdd")}";
            });

            Console.WriteLine("Hello, World!");
        }
    }
}
