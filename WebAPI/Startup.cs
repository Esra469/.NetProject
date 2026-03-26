using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //içeride veri tutulmuyorsa singleton kullanılır. 
            services.AddControllers();
            services.AddSingleton<IProductService, ProductManager>();//demek isityor ki "IProductService" bunda bir bağımlılık görürsen onun karşılığı ProductManager dır. 

            services.AddSingleton<IProductDal,EfProductDal>();

        }
    }
}
