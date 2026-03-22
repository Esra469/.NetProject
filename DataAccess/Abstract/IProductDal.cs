using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{    //data accessin entitiese bağlı olduğunu bu şekilde belirtiyoruz.Dataaccess altında dependencies altına entities geldi., IEntitiesRepositorye yolladık
    //product tablosunu dalını yazıyoruz. Data access layour demek.
    public interface IProductDal:IEntityRepository<Product>
    {
        
       
    }
}

//Code refectoring