using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    //Bussines bizim iş katmanı
    public interface IProductService
    {
        //ampulden using categoty entites ekledik,bağlı olan folderler
        List<Product> GetAll();
        List<Product> GelAllByCategoryId(int id);
        List<Product> GelAllByUnitPrice(decimal min, decimal max);
        List<ProductDetailDto> GetProductDetailDtos();

        Product GetById(int productId);
        IResult Add(Product product);
    }
}
