using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //attribute
    public class ProductsController : ControllerBase
    {
        //loosely coupled
        //constructor verdiğimzde aşağıdan istediğimiz gbi erişemeyiz. ama _productService dyince field ine ulaşmış oluyoruz. ordan oynama yapabiliyoruz.
        //IoC container --Inversion of control
        IProductService _productService;


        //constructor oluşturduk.
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            //return new List<Product>
            //{
            //    new Product{ProductId=1,ProductName="Elma"},
            //    new Product{ProductId=2,ProductName="Armut"},
            //};

            //Dependency chain 
           // IProductService productService = new ProductManager(new EfProductDal()); //Product manager yazmadık. IProductservice yazdık çünkü referansını tutuyor.
           
            var result =productService.GetAll();
            return result.Data;
        }
    }
}
