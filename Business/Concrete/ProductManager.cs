using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    //bir iş sınıfı başka sınıfları new lemez -> kural//onun yerine _ (alt çizgi kullanır. injection)
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager (IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business codes

            if (product.ProductName.Length < 0)
            {
                return new errorResult("ürün ismi en az 2 karakter olmalıdır.");
            }
            _productDal.Add(product);
            return new SuccessResult("Ürün Eklendi");


        }

        public List<Product> GelAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GelAllByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);

        }


        public List<Product> GetAll()
        {
            //iş kodları
            return _productDal.GetAll();
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p=>p.ProductId==productId);
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            return _productDal.GetProductDetails();
        }
    }
}
