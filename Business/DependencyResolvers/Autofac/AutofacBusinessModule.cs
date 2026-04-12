using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Business.CSS;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module //Module yazınca önce hata verecek açılır pencerede autofac seç
    {
        protected override void Load(ContainerBuilder builder) //programı ilk çalıştırdığında çalışacak olan alandır.
        {
            //program.cs de belirtiğimiz bağımlılık aslında
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();//biri bizden Iproductservice isterse product manager yönlendir demek.
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance() ;
            builder.RegisterType<FileLogger>().As<ILogger>().SingleInstance() ;


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();


        }

    }
}
