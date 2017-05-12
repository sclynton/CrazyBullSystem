using CrazyBull.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyBull.Entity.Repository;

namespace CrazyBull.Data.Repositrories
{
    public class Repository<T> : IRepository<T> where T : Entity.Entity
    {
        private readonly NovelBookDbContext _dbContext;
        public Repository(NovelBookDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            throw new Exception();
        }

        public async Task<int> InsertAsync(T t)
        {
            _dbContext.Add(t);
            await _dbContext.SaveChangesAsync();
            return t.Id;
        }
    }
}
