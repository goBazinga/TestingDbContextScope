using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Mehdime.Entity;
using TestingDbContextScope.Data;


namespace TestingDbContextScope.Service
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void AddProductDetail(ProductDetail productDetail);
    }
}
