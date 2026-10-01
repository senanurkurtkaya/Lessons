using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndFunctions.Services
{
    internal class ProductSyncService<TProduct>
    {
        public void Sync(List<TProduct> products) 
        { 
            // Ürünleri x pazaryoluna gönder
        }

        public void UpdatePrices(List<TProduct> products)
        {
            // ürün fiyatlarını güncelle
        }

        public void ActivateProduct(TProduct product)
        {
            // ürünü aktifleştir
        }

        public void DeactiveProduct(TProduct product)
        {
            // ürünü pasife al
        }
    }
}
