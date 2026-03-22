
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    
    // Buraya IEntity veremem çünkü IEntity i veritabnında alacağım tek nesnelere vereceğim.
    // ama burada veritabanından aldığım birçok toblonun joinini kullanacağım  için IDto vereceğim
    
    public class ProductDetailDto:IDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public short UnitsInStock { get; set; }
    }
}
