using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheSearchApp.DataManager.Repositories
{
    public interface ICommonRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        void Add(T t);
        void Edit(T t);
        void Delete(T t);
        IQueryable<T> GetManyQueryable(Func<T, bool> where);
    }
}
