using CompnayWebsite_DataAccessLayer.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CompnayWebsite_DataAccessLayer.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _applicationDBContext;
        internal DbSet<T> dbSet;


        public Repository(ApplicationDBContext applicationDBContext)
        {
            _applicationDBContext = applicationDBContext;
            this.dbSet = applicationDBContext.Set<T>();
        }


        public void Add(T element)
        {
            _applicationDBContext.Add(element);
        }

        public void Remove(T element)
        {
            _applicationDBContext.Remove(element);
        }

        public T Find(int id)
        {
            return _applicationDBContext.Find<T>(id);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.FirstOrDefault();

        }



        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return query.ToList();
        }

        public void Save()
        {
            _applicationDBContext.SaveChanges();
        }

        public IEnumerable<TResult> GroupBy<TResult>(
        Expression<Func<T, TResult>> groupBy,
        Expression<Func<T, bool>> filter = null,
        string includeProperties = null)
        {
            IQueryable<T> query = _applicationDBContext.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.GroupBy(groupBy).Select(g => g.Key);
        }


    }
}
