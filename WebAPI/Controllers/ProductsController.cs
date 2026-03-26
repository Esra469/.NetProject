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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //return new List<Product>
            //{
            //    new Product{ProductId=1,ProductName="Elma"},
            //    new Product{ProductId=2,ProductName="Armut"},
            //};

            //Dependency chain 
           // IProductService productService = new ProductManager(new EfProductDal()); //Product manager yazmadık. IProductservice yazdık çünkü referansını tutuyor.
           
            var result = _productService.GetAll();
            if(result.Success)
            {
                return Ok(result); //ok 200 olma durumunda postmandaki standart get yapma esnasında alınan bilgilere denk gelir.
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result=_productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
