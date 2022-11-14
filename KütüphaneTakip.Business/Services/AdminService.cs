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
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Reservation> _reservationRepository;


        public AdminService(IRepository<Category> categoryRepository, IRepository<Book> bookRepository, IRepository<Author> authorRepository, IRepository<User> userRepository, IRepository<Reservation> reservationRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _userRepository = userRepository;
            _reservationRepository = reservationRepository;
        }
        public List<User> AllUser()
        {
            return _userRepository.GetAll().ToList();
        }
        public async Task AddUser(User user)
        {
            user.CDate = DateTime.Now;
            await _userRepository.AddAsync(user);
        }
        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }
        
        public async Task<User> EditUser(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user;
        }
        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
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
        public async Task AddBook(Book book)
        {
            book.BookStatu= BookStatu.Boşta;
            book.CDate = DateTime.Now;
            await _bookRepository.AddAsync(book);

        }
        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }
        public async Task<Book> EditBook(int id)
        {
            var list = await _bookRepository.GetByIdAsync(id);
            return list;
        } // burdan update e yönlendir.
        public void UpdateBook(Book book)
        {
            _bookRepository.Update(book);
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
        public async Task<Author> EditAuthor(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            return author;
        }//-----------------------eklendi
        public void UpdateAuthor(Author author)
        {
            _authorRepository.Update(author);
        }
        public List<Reservation> AllReservation()
        {
            return _reservationRepository.GetAll().ToList();

        }

        public async Task AddReservation(Reservation reservation)
        {
            //reservation.CDate = DateTime.Now;
            await _reservationRepository.AddAsync(reservation);

        }
        public void DeletReservation(int id)
        {
            _reservationRepository.Delete(id);
        }
        public async Task<Reservation> EditReservation(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            return reservation;
        }
        public void UpdateReservation(Reservation reservation)
        {
            _reservationRepository.Update(reservation);
        }

		public async Task<string> AdminFullName(string email)
		{
            var user = await _userRepository.Where(x => x.Email == email).FirstOrDefaultAsync();

            return $"{user.FullName} ";
        }
	}
}
