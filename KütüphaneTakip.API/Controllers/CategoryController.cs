using KütüphaneTakip.Core.Entites;
using KütüphaneTakip.Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            await _categoryRepository.AddAsync(category);
            return Ok();
        }
        [HttpGet]
        [Route("GetByIdCategory/{id}")]
        public async Task<IActionResult> GetByIdCategory(int id)
        {
            var entity = await _categoryRepository.GetByIdAsync(id);
            return Ok(entity);


        }

        [HttpGet]
        [Route("GetCategory")]        
        public List<Category> GetAllCategory()
        {
            return _categoryRepository.GetAll().ToList();
            
        }
        [HttpDelete]
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(int id)
        {
           _categoryRepository.Delete(id);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var ee =await _categoryRepository.GetByIdAsync(category.Id);
            ee.CategoryName = category.CategoryName;
            ee.CDate = category.CDate;
            _categoryRepository.Update(ee);
            return Ok(ee);
        }







    }





}
