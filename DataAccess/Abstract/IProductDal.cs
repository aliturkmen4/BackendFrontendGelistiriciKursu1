using Entities.Concrete;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract //veriye erişimi yaptığımız yer(insert-update-delete vs)
{
    public interface IProductDal:IEntityRepository<Product> //sen bir IEntityRepository sin ve bir productla çalışacaksın dedim!
    {

    }

}
