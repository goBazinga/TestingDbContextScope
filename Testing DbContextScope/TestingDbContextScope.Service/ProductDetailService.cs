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
    public class ProductDetailService : IProductDetailService
    {
        private readonly IRepository<ProductDetail> _productDetailRepository;
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        public ProductDetailService(IRepository<ProductDetail> productDetailRepository, IDbContextScopeFactory dbContextScopeFactory)
        {
            this._productDetailRepository = productDetailRepository;
            _dbContextScopeFactory = dbContextScopeFactory;
        }

        public void AddProductDetail(ProductDetail productDetail)
        {
            using (var dbcontextscope = _dbContextScopeFactory.Create())
            {
                _productDetailRepository.Insert(productDetail);
                dbcontextscope.SaveChanges();
            }
        }
    }
}
