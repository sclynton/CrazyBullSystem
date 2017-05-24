using System;
using System.Collections.Generic;
using System.Text;
using CrazyBull.Application.Books.Dtos;
using CrazyBull.Core;
using System.Threading.Tasks;
using AutoMapper;

namespace CrazyBull.Application
{
    public class CategoryService : ICategoryService
    {
        private IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoryOutputDto>> GetCategoryListByParentId(int parentId)
        {
            var list = await _categoryRepository.GetAll();
            return Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryOutputDto>>(list);
        }
    }
}
