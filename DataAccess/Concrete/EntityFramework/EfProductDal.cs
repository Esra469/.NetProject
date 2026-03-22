using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //NuGet -core.sql kurduk
    public class EfProductDal : EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal//bu şekilde yaparak veri tabanı operasyonlarını yazmaya hazır oluruz.
    {
       
    }
}
