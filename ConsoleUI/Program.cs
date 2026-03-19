using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ben inmemory çalışacağım
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var product in productManager.GelAllByCategoryId(2))//2 kategorisindeki ürünleri alır.
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
