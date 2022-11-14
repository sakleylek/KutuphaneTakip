using KütüphaneTakip.Business.Services;
using KütüphaneTakip.Core.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace KütüphaneTakip.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly AdminService _adminService;
        private readonly UserService _userService;

        public UserController(AdminService adminService, UserService userService)
        {
            _adminService = adminService;
            _userService = userService;
        }


        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Books()
        {

            var list = _userService.AllBooks();
            return View(list);
        }
        public async Task<IActionResult> BookReservation(int id)
        {
            
            var reservation = new Reservation();
            reservation.BookId = id;
            
            return View("BookReservation",reservation);
        }
        






        private List<SelectListItem> ReservationType()
        {
            string[] listRole = { "TalepEdildi", "Onaylandı", "Red", "Boşta" };
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in listRole)
            {
                items.Add(new SelectListItem { Text = item, Value = item.ToString() });
            }
            return items;
        }
    }
}
