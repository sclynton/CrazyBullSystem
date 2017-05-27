using System;
using System.Collections.Generic;
using System.Text;
using CrazyBull.Application.Books.Dtos;
using CrazyBull.Core;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace CrazyBull.Application
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoryOutput>> GetCategoryListByParentIdAsync(int parentId)
        {
            var list = await _categoryRepository.GetAll().Where(c=>c.ParentId == parentId).ToListAsync();
            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryOutput>>(list);
        }
    }
}
