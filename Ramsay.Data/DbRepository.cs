using Microsoft.EntityFrameworkCore;
using Ramsay.Models.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ramsay.Data
{
   public class DbRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly RamsayDbContext _dbContext;

        private readonly DbSet<TEntity> _dbSet;



        public DbRepository(RamsayDbContext context,
            DbSet<TEntity> dbSet)
        {
            this._dbContext = context;
            this._dbSet = dbSet;
          
        }

        public Task AddAsync(TEntity entity)
        {
            return this._dbContext.AddAsync(entity);
        }

        public IQueryable<TEntity> All()
        {
            return this._dbSet;
        }

        public void Delete(TEntity entity)
        {
            this._dbSet.Remove(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return this._dbContext.SaveChangesAsync();
        }

    }
}
