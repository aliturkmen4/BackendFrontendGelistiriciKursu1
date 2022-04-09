using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId)); //yukarıda dependency injection uygulayarak ef e bağımlılığını kaldırdım!
        }
        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>> (_productDal.GetList(p => p.CategoryId == categoryId).ToList());
        }
        public IResult Add(Product product)
        {
            //Business codes => buraya iş kodlarını yazarsın örneğin daha önce eklenen bir ürünün isminin bir daha eklenememesi gibi veya validation kodları!
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded); //buradaki mesajlara string bir şekilde yazarsam MAGIC STRING DENİR! bu ileride karışıklığa sebebiyet verebileceği için business katmanı altında constants klasörene bir static messages class'ı oluşturup mesajlarımı oradan aldım!
        }
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }
        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
