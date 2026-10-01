using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndFunctions.Models
{
    internal class ElasticProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal BasePrice { get; set; }

        public decimal Price { get; set; }

        public string StockCode { get; set; }

        public string Barcode { get; set; }

        public int StockAmount { get; set; }

        public string Variant { get; set; }
    }
}
