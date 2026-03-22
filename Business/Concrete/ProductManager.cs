using Business.Abstract;
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
        IProductDal _ProductDal;

        public ProductManager (IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        public List<Product> GelAllByCategoryId(int id)
        {
            return _ProductDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GelAllByUnitPrice(decimal min, decimal max)
        {
            return _ProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);

        }


        public List<Product> GetAll()
        {
            //iş kodları
            return _ProductDal.GetAll();
        }

        public List<ProductDetailDto> GetProductDetailDtos()
        {
            return _ProductDal.GetProductDetails();
        }
    }
}
