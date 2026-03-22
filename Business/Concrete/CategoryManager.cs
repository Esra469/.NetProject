using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal; //bağımlılığı minimize etmeye çalışıyoruz.(injection)

        //constractor,refereans üzerinden bağımlı
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }


        //Buraya iş kodları yazılır.
        public List<Category> GetAll()
        {
           return _categoryDal.GetAll();
        }

        //select * from categories where categoryId=3 , aşağıdaki metod bunun gibi çalışıyor aslında
        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryID == categoryId);
        }
    }
}
