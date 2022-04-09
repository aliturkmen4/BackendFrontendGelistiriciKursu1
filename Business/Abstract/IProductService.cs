using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService //operasyonları bu şekilde primitive tipler ya da objelerle yazmaya dikkat et! //business katmanında generic kullanmamaya dikat et! (saf bir şekilde yaz!)
    {
        IDataResult<Product> GetById(int productId);

        IDataResult<List<Product>> GetList();

        IDataResult<List<Product>> GetListByCategory(int categoryId);

        IResult Add(Product product); //bir ürünü eklemek için! //ıresult türünde başarılı mı oldum başarısız mı onu kontrol etmek istiyorum!

        IResult Delete(Product product);

        IResult Update(Product product);

    }
}
