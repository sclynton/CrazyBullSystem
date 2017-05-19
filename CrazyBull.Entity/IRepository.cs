using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyBull.Core
{
    public interface IRepository<T>
    {
        Task<int> InsertAsync(T t);

        Task<IEnumerable<T>> GetAll();
    }
}
