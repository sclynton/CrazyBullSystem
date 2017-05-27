using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrazyBull.Core
{
    public interface IRepository<T>
    {
        Task<int> InsertAsync(T t);

        IQueryable<T> GetAll();
    }
}
