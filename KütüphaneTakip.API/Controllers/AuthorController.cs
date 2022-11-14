using KütüphaneTakip.Core.Entites;
using KütüphaneTakip.Core.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneTakip.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IRepository<Author> _authorRepository;

        public AuthorController(IRepository<Author> authorRepository)
        {
            _authorRepository = authorRepository;
        }
        [HttpGet]
        [Route("GetByIdAuthor/{id}")]
        public async Task<IActionResult> GetByIdAuthor(int id)
        {
            var entity = await _authorRepository.GetByIdAsync(id);
            return Ok(entity);

        }
        [HttpPost]
        [Route("AddAuthor")]
        public async Task<IActionResult> AddAuthor(Author author)
        {

            await _authorRepository.AddAsync(author);
            return Ok(author);
        }
        [HttpGet]
        [Route("GetAuthor")]
        public List<Author> GetAllAuthor()
        {
            return _authorRepository.GetAll().ToList();
        }
        [HttpDelete]
        [Route("DeleteAuthor")]
        public IActionResult DeleteAuthor(int id)
        {
            _authorRepository.Delete(id);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor(Author author)
        {
            var ee = await _authorRepository.GetByIdAsync(author.Id);
            ee.AuthorName = author.AuthorName;
            ee.CDate = author.CDate;
            _authorRepository.Update(ee);
            return Ok(ee);
        }
    }
}
