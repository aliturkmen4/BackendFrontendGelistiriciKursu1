using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    //vurayı yaptıktan sonra artık EfProductDal'ın içerisinde ürün ekleme silme güncellemem hazır!
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity> //EfEntityRepository IEntity Repository'i implemente ettiği için operasyonlar geldi!
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using(var context=new TContext()) //unit of work patternini implemente eder!
            {
               var addedEntity= context.Entry(entity); //entry ef den geliyor! gönderilen entity e entity context i abone ediyorum aslında!
                addedEntity.State = EntityState.Added;
                context.SaveChanges(); //veri tabanına eklemek istediğimi söyledim!
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext()) //using => disposable pattern : nesnenin hayatını sonlandırmasını GC e bırakmıyorum, bellekten silinmesini sağlıyorum Context pahalı bir nesne olduğu için kullanılmayınca ne kadar çabuk öldürürsem o kadar iyi!
            {
                var deletedEntity = context.Entry(entity); 
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges(); //veri tabanına silmek istediğimi söyledim!
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter); //bu da bir abone olma operasyonu aslında TEntity için, burada select sorgularımızı yazıyoruz, tek bir nesne olacağı için singleordefault diyerek o datanın gelmesini sağlıyorum!
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null) //filtre gönderilmemişse tamamını getirmek, filtre gönderilmişse filtreye göre getirmek istiyorum!
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext()) 
            {
                var updatedEntity = context.Entry(entity); 
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges(); //veri tabanına güncellemek istediğimi söyledim!
            }
        }
    }
}
