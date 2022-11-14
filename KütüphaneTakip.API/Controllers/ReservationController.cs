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
    public class ReservationController : ControllerBase
    {
        private readonly IRepository<Reservation> _reservationRepository;

        public ReservationController(IRepository<Reservation> reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
        [HttpGet]
        [Route("GetByIdReservation/{id}")]
        public async Task<IActionResult> GetByIdReservation(int id)
        {
            var entity = await _reservationRepository.GetByIdAsync(id);
            return Ok(entity);

        }
        [HttpPost]
        [Route("AddReservation")]
        public async Task<IActionResult> AddReservation(Reservation Reservation)
        {
            await _reservationRepository.AddAsync(Reservation);
            return Ok(Reservation);
        }
        [HttpGet]
        [Route("GetReservation")]
        public List<Reservation> GetAllReservation()
        {
            return _reservationRepository.GetAll().Include(x=>x.User).ToList();
        }
        [HttpDelete]
        [Route("DeleteReservation")]
        public IActionResult DeleteReservation(int id)
        {
            _reservationRepository.Delete(id);
            return Ok();
        }
        [HttpPut]
        [Route("UpdateReservation")]
        public async Task<IActionResult> UpdateReservation(Reservation Reservation)
        {
            var ee = await _reservationRepository.GetByIdAsync(Reservation.Id);
            ee.BookId = Reservation.BookId; //buraya bak!!!
            ee.StartDate = Reservation.StartDate;
            _reservationRepository.Update(ee);
            return Ok(ee);
        }
    }
}
