using Business.Abstract;
using Business.Constants;
using Business.CSS;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILogger = Business.CSS.ILogger;

namespace Business.Concrete
{
    //bir iş sınıfı başka sınıfları new lemez -> kural//onun yerine _ (alt çizgi kullanır. injection)
    //_ (alt çizgi kullanımıda yani constructor çağırmamızda amacımız direkt classı kullanmak değil onun üzerinden onun muş gibi işlem yapmaktır.)
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
       

        public ProductManager (IProductDal productDal)
        {
            _productDal = productDal;
            
        }

       [ValidationAspect(typeof(ProductValidator))]// add metodunu doğrula productValidator daki kurallara göre demek oluyor 
        public IResult Add(Product product)
        //bussines code

        {   /*
             diyelim ki üst yönetim bize dedi ki kural olarak her kategoride en fazla 10 ürün olsun.
             Bu durun iş parçacığının onaylanacağı bir iş olacaktır.dolayısıyla bu kısma yazılmalı.
            her durum için ayrı güncelleme veya fonksiyon gerekeceği için ayrı bir fonksiyon ile o işleri de ayrıdık. private belirtik ki sadce orada kullanılsın.
            */
            //bu kuralla uygun kodu yaz
            //Aynı isimden ürün eklenemez.
            //mevcut kategori 15 i geçişse artık kategori ekleme. 

           IResult result= BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameExist(product.ProductName));

            if (result != null)
            {
                return result;
            }
            if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                if (CheckIfProductNameExist(product.ProductName).Success)
                {
                    _productDal.Add(product);
                    return new SuccessResult(Messages.ProductAdded);
                }
            }
            return new ErrorResult();
            
        
            //business codes
            //validation doğrulama kodu ve iş kodu farklı -burada yazdığımız kodları product validationa attık.

            //[ValidationAspect(typeof(ProductValidator))] bunu eklediğimiz için aşağıdaki kod egele oldu 
            //ValidationTool.Validate(new ProductValidator(), product);

            

        }

        public IDataResult<List<Product>> GelAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<List<Product>> GelAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));

        }


        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 1)//burada 1 olmasının sebebi saate göre ayaladık. saatin ileisinde verirsem errormessage döndürür.
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            //iş kodları
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }




        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product> (_productDal.Get(p=>p.ProductId==productId));
        }

       

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>> (_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count();
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        //Örnek bir iş parçacığı kuralı
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //select count(*) from products where categoryId=1
            var result=_productDal.GetAll(p=>p.CategoryId== categoryId).Count;
            if(result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryCount()
    }
}
