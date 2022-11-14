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
    public class BookController : ControllerBase
    {
        private readonly IRepository<Book> _bookRepository;

        public BookController(IRepository<Book> BookRepository)
        {
            _bookRepository = BookRepository;
        }
        [HttpGet]
        [Route("GetByIdBook/{id}")]
        public async Task<IActionResult> GetByIdBook(int id)
        {
            var entity = await _bookRepository.GetByIdAsync(id);
            return Ok(entity);

        }
        [HttpPost]
        [Route("AddBook")]
        public async Task<IActionResult> AddAuthor(Book book)
        {
            await _bookRepository.AddAsync(book);
            return Ok(book);
        }
        [HttpGet]
        [Route("GetBook")]
        public List<Book> GetAllBook()
        {
            return _bookRepository.GetAll().Include(x=>x.Category).Include(x=>x.Author).ToList();
        }
        [HttpDelete]
        [Route("DeleteBook")]
        public IActionResult DeleteBook(int id)
        {
            _bookRepository.Delete(id);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateBook")]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            var ee = await _bookRepository.GetByIdAsync(book.Id);
            ee.Name = book.Name;
            ee.CDate = book.CDate;
            _bookRepository.Update(ee);
            return Ok(ee);
        }
    }
}
