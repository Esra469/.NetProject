using Business.Abstract;
using Core.Utilities.Results;
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
        public IDataResult<List<Category>> GetAll()
        {
           return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        //select * from categories where categoryId=3 , aşağıdaki metod bunun gibi çalışıyor aslında
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryID == categoryId));
        }

        IDataResult<List<Category>> ICategoryService.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
