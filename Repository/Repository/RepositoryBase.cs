using System;
using System.Linq;
using System.Linq.Expressions;
using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ProjectDbContext projectContext;
        public RepositoryBase(ProjectDbContext repositoryContext)
        {
            projectContext = repositoryContext;
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return !trackChanges ? projectContext.Set<T>().AsNoTracking() : projectContext.Set<T>();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return !trackChanges ?
                        projectContext.Set<T>()
                        .Where(expression)
                        .AsNoTracking() :
                        projectContext.Set<T>()
                        .Where(expression);
        }
        public void Create(T entity) => projectContext.Set<T>().Add(entity);
        public void Update(T entity) => projectContext.Set<T>().Update(entity);
        public void Delete(T entity) => projectContext.Set<T>().Remove(entity);
    }
}
