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
    public class ProductService: IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<ProductDetail> _productDetailRepository;

        public ProductService(IRepository<Product> productRepository ,
            IRepository<ProductDetail> productDetailRepository, IDbContextScopeFactory dbContextScopeFactory)
        {
            this._productDetailRepository = productDetailRepository;
            this._productRepository = productRepository;
            _dbContextScopeFactory = dbContextScopeFactory;
        }

        public void AddProduct(Product product)
        {
            using (var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var prod = _productRepository.GetById(1);
                //_productRepository.Insert(product);
                prod.Name = "CHANGED 11111111111";
                _productRepository.Update(product);
                AddProductDetail(new ProductDetail() { ProductId = product.Id, CostPrice = "100", SalePrice = "500.00"});

                dbcontextscope.SaveChanges();
            }
        }

        public void AddProductDetail(ProductDetail productDetail)
        {
            using (var dbcontextscope = _dbContextScopeFactory.Create())
            {
                var prodDetail = _productDetailRepository.GetById(productDetail.Id);
                prodDetail.CostPrice = productDetail.CostPrice;
                prodDetail.SalePrice = productDetail.SalePrice;
                _productDetailRepository.Delete(prodDetail);
                _productDetailRepository.Insert(prodDetail);
                dbcontextscope.SaveChanges();
            }
        }
    }
}
