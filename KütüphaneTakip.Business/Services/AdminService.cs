using KütüphaneTakip.Core.Entites;
using KütüphaneTakip.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KütüphaneTakip.Business.Services
{
    public class AdminService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Author> _authorRepository;


        public AdminService(IRepository<Category> categoryRepository, IRepository<Book> bookRepository, IRepository<Author> authorRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }
        public List<Category> AllCategory()
        {
            return _categoryRepository.GetAll().ToList();
        }
        public async Task AddCategory(Category category)
        {
            category.CDate = DateTime.Now;
            await _categoryRepository.AddAsync(category);

        }
        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        } // 

        public async Task<Category> EditCategory(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category;
        } // burdan update e yönlendir.
        public void UpdateCategory(Category category)
        {
            _categoryRepository.Update(category);
        }


        public List<Book> AllBooks()
        {
            return _bookRepository.GetAll().Include(x=>x.Category).Include(x=>x.Author).ToList();
            
        }

        public List<Author> AllAuthor()
        {
            return _authorRepository.GetAll().ToList();

        }

        public async Task AddAuthor(Author author)
        {
            author.CDate = DateTime.Now;
            await _authorRepository.AddAsync(author);

        }
        public void DeleteAuthor(int id)
        {
            _authorRepository.Delete(id);
        }
        public void UpdateAuthor(Author author)
        {
            _authorRepository.Update(author);
        }

        public async Task AddBook(Book book)
        {
            book.CDate = DateTime.Now;
            await _bookRepository.AddAsync(book);

        }
    }
}
