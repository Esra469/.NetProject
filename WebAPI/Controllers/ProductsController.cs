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
        [HttpGet]
        public List<Product> Get()
        {
            //return new List<Product>
            //{
            //    new Product{ProductId=1,ProductName="Elma"},
            //    new Product{ProductId=2,ProductName="Armut"},
            //};
            IProductService productService = new ProductManager(new EfProductDal());
            var result =productService.GetAll();
            return result.Data;
        }
    }
}
