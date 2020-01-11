using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RestaurantAPI.Entities.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        protected RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            ApplicationDbContext = applicationDbContext;
        }
        //int pageSize, int pageIndex paged
        //return ApplicationDbContext.Set<T>().Skip(pageSize * pageIndex).Take(pageSize);
        public IQueryable<T> ListAll()
        {
            return ApplicationDbContext.Set<T>();
        }
        //public IQueryable<T> ListByCondition(Expression<Func<T, bool>> expression, int pageSize, int pageIndex)
        //{
        //    return ApplicationDbContext.Set<T>().Where(expression).Skip(pageSize * pageIndex).Take(pageSize);
        //}
        public IQueryable<T> ListByCondition(Expression<Func<T, bool>> expression)
        {
            return ApplicationDbContext.Set<T>().Where(expression);
        }

        public async Task<T> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await ApplicationDbContext.Set<T>().SingleOrDefaultAsync(expression);
        }

        public async Task<bool> CheckAnyByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await ApplicationDbContext.Set<T>().AnyAsync(expression);
        }

        public void Create(T entity)
        {
            ApplicationDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.ApplicationDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.ApplicationDbContext.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await this.ApplicationDbContext.SaveChangesAsync();
        }
    }
}
