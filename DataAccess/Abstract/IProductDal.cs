using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    //product tablosunu dalını yazıyoruz. Data access layour demek.
    public interface IProductDal:IEntityRepository<Product>
    {
        //data accessin entitiese bağlı olduğunu bu şekilde belirtiyoruz.Dataaccess altında dependencies altına entities geldi., IEntitiesRepositorye yolladık
       
    }
}
