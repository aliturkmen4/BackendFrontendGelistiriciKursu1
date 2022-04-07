using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T:class,IEntity,new() //burada veri tabanına eklediğim nesne referans olan IEntity den newlenebilir her şeyi gönderebileceğimi söyledim! (IEntiity interface olduğu için newlenemez!)
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList(Expression<Func<T, bool>> filter=null); //filtre gönderilmezse tümünü listelesin diye nullable olarak verdim!

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
