using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDbContextScope.Data
{
    public class ProductDetail: BaseEntity
    {
        public int ProductId { get; set; }
        public string CostPrice { get; set; }
        public string SalePrice { get; set; }
        public string Manufacturer { get; set; }
    }
}
