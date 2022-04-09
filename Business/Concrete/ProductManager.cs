using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService //bu isimlendirmeyi ekstra bir durum yoksa servis katmanında kullanırsın!
    {
        private IProductDal _productDal; //dependency injection uygulayabilmek için bir field oluşturdum!

        public ProductManager (IProductDal productDal) //burada IProductDal bir referans tip! (burada IProductDal'ı kim implemente ediyorsa onu verebilirim!)
        {
           this. _productDal = productDal;
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId); //yukarıda dependency injection uygulayarak ef e bağımlılığını kaldırdım!
        }
        public List<Product> GetList()
        {
            return _productDal.GetList().ToList();
        }
        public List<Product> GetListByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId).ToList();
        }
        public void Add(Product product)
        {
            //Business codes => buraya iş kodlarını yazarsın örneğin daha önce eklenen bir ürünün isminin bir daha eklenememesi gibi veya validation kodları!
            _productDal.Add(product);
        }
        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }
        public void Update(Product product)
        {
            _productDal.Update(product);
        }
    }
}
