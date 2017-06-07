using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrazyBull.Application;

namespace CrazyBull.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Category")]
    public class CategoryController : Controller
    {
        public ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [Route("list")]
        public async Task<IActionResult> GetCategoriesByParentId(int parentId = 0)
        {
            var categoies = await _categoryService.GetCategoryListByParentIdAsync(parentId);
            return new ObjectResult(categoies);
        }
    }
}