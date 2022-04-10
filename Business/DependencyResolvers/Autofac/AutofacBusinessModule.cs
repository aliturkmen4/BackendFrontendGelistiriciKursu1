using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module //burada module yazıp using.autofac yaptım bu bize overrideble bir ortam sunuyor!
    {
        protected override void Load(ContainerBuilder builder) //adı üstünde yükle(konfigürasyonu yaptığımız yer olacak!)
        {
            builder.RegisterType<ProductManager>().As<IProductService>(); //productmanager tipimi register et dedim! //bu şey demek birisi IProductService şeklinde bir isterse constructorında  biz ona ProductManager veriyor olacağız!
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>(); 
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
        }
    }
}
