using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages//static verildiğinde new'lemesini engelledik
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
       // internal static  MaintenanceTime="Sistem bakımda";
        internal static string ProductsListed="Ürünler Listelendi";
        internal static List<Product> MaintenanceTime;
    }
}
