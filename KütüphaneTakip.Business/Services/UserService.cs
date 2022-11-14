using KütüphaneTakip.Core.Entites;
using KütüphaneTakip.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneTakip.Business.Services
{
    public class UserService
    {
        private readonly IRepository<Reservation> _reservationRepository;
        private readonly IRepository<Book> _bookRepository;

        public UserService(IRepository<Reservation> reservationRepository, IRepository<Book> bookRepository)
        {
            _reservationRepository = reservationRepository;
            _bookRepository = bookRepository;
        }
        public async Task<Book> EditReservation(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            
            return book;            
        }
        public List<Book> AllBooks()
        {

            return _bookRepository.GetAll().Include(x => x.Category).Include(x => x.Author).ToList();
        }
        //public int GetBookId(int id)
        //{
        //    return _bookRepository.Where(x => x.Id == id).FirstOrDefault().Id;
        //}
    }
}
