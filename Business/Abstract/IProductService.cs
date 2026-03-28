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
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GelAllByCategoryId(int id);
        IDataResult<List<Product>> GelAllByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails(); //IDataResult hangi tip olarak belirteceğimize yardımıcı olur.

        IDataResult<Product> GetById(int productId);//Tek bir ürüne hitap ettiği için List<> diye belirtmemize gerek kalmadı
        IResult Add(Product product); //IResult void yerine yazıldı.
    }
}
