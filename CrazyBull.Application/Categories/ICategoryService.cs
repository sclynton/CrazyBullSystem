using CrazyBull.Application.Books.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrazyBull.Application
{
    public interface ICategoryService : IService
    {
        Task<IEnumerable<CategoryOutput>> GetCategoryListByParentIdAsync(int parentId);
    }
}
