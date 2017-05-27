using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyBull.Core;
using Microsoft.EntityFrameworkCore;

namespace CrazyBull.MySql.EntityFramework
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly CrazyBullDbContext _dbContext;
        public Repository(CrazyBullDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public async Task<int> InsertAsync(T t)
        {
            _dbContext.Add(t);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
