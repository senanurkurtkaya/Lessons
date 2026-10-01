using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndFunctions.Services
{
    internal class AnotherSyncService
    {
        public void Sync<TProduct>(List<TProduct> products)
        {
            // ürünleri sync et.
        }

        public void SyncWithElastic<TProduct, TElasticProducts>(List<TProduct> products, List<TElasticProducts> elasticProducts)
        {
            // ürünleri elastic ile kontrol ederek sync et.
        }

        public void SyncWithElastic<TProduct, TElasticProducts>(
            List<TProduct> products, 
            List<TProduct> newProducts, 
            List<TElasticProducts> elasticProducts)
        {
            // ürünleri yeni ürünlerle kıyasla, elastic ile kontrol ederek sync et.
        }

        public TElasticProduct ConvertToElastic<TProduct, TElasticProduct>(TProduct product)
        {
            return (TElasticProduct)new object();
        }
    }
}
