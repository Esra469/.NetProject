using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


//core klasöründe kullanacağımız tüm temel yapıları kuracağız. ilk iş olarak DataAccess altındaki abstract altındaki IEntitiyRepository i core altındaki DataAccess klasörüne taşıdık.
namespace Core.DataAccess
{
 //Bu şekilde T çok genel bir type oluyor. random bir yerde int de yazsa kabul edeblr. dolayısıyla sadece T değl başka aşağıdaki şekilde yapılandırmamız lazım. (Generic constraint)
 //class: reference tip
 //IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir.
 //new : new'lenebilir olmalı ,IEntity normalde interface olduğu için new lenemez ama new ekleme durumunda olablri
    public interface IEntityRepository<T> where T : class,IEntity //class demek referans tip olabilir demek./ T ya referasn tip olabilr ya da IEntity olabilr ya da IEntitden implemente olan bir şey olabilir.
    {
        //Expressionn filtre olulturmamızı sağlar. LINQ da kullandıpımız gibi, kategorye göre name göre filtreleme mesela
        List<T> GetAll(Expression<Func<T,bool>>filter=null);
        T Get(Expression<Func<T,bool>>filter);
        void Add(T product);
        void Update(T product);
        void Delete(T product);

        //ürünleri kategoriye göre listele
        List<T> GetAllByCategory(int categoryId);
    }
}
