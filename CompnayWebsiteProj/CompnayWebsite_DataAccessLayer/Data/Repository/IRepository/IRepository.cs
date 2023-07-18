using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompnayWebsite_DataAccessLayer.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        T Find(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        T FirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
            );

        void Add(T element);

        void Remove(T element);

        void Save();

        IEnumerable<TResult> GroupBy<TResult>(
        Expression<Func<T, TResult>> groupBy,
        Expression<Func<T, bool>> filter = null,
        string includeProperties = null );

    }
}
