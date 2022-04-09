using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService //operasyonları bu şekilde primitive tipler ya da objelerle yazmaya dikkat et! //business katmanında generic kullanmamaya dikat et! (saf bir şekilde yaz!)
    {
        Product GetById(int productId);

        List<Product> GetList();

        List<Product> GetListByCategory(int categoryId);

        void Add(Product product); //bir ürünü eklemek için!

        void Delete(Product product);

        void Update(Product product);

    }
}
