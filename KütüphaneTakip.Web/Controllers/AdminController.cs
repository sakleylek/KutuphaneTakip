using KütüphaneTakip.Business.Services;
using KütüphaneTakip.Core.Entites;
using KütüphaneTakip.Web.Attributes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneTakip.Web.Controllers
{
    [Authorize]
    [ClaimRequirement("Admin")]
    public class AdminController : Controller
    {

        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UpdateUser(User user)
        {
            _adminService.UpdateUser(user);
            return RedirectToAction("AllUser");
        }
        public async Task<IActionResult> AllBooks()
        {

            var list = _adminService.AllBooks();
            return View(list);
        }

        public IActionResult NewBook()
        {
            var items = ListAuthor();
            var category = ListCategory();
            ViewBag.Authors = items;
            ViewBag.Categories = category;

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewBook(Book book)
        {
            await _adminService.AddBook(book);
            return RedirectToAction("AllBooks");
        }
        public IActionResult DeleteBook(int id)
        {
            _adminService.DeleteBook(id);
            return RedirectToAction("AllBooks");
        }
        public async Task<IActionResult> EditBook(int id)
        {
            var items = ListAuthor();
            var category = ListCategory();
            ViewBag.Authors = items;
            ViewBag.Categories = category;
            var book = await _adminService.EditBook(id);
            return View("EditBook", book);
        }
        public IActionResult UpdateBook(Book book)
        {

            _adminService.UpdateBook(book);
            return RedirectToAction("AllBooks");
        }
        public IActionResult AllCategory()
        {
            var list = _adminService.AllCategory();
            return View(list);
        }
        public IActionResult NewCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewCategory(Category category)
        {
            await _adminService.AddCategory(category);
            return RedirectToAction("AllCategory");
        }
        public IActionResult DeleteCategory(int id)
        {
            _adminService.DeleteCategory(id);
            return RedirectToAction("AllCategory");
        }
        public async Task<IActionResult> EditCategory(int id)
        {
            var category = await _adminService.EditCategory(id);
            return View("EditCategory", category);

        }
        public IActionResult UpdateCategory(Category category)
        {
            _adminService.UpdateCategory(category);
            return RedirectToAction("AllCategory");
        }
        public async Task<IActionResult> AllAuthor()
        {
            var list = _adminService.AllAuthor();
            return View(list);

        }
        public IActionResult NewAuthor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewAuthor(Author author)
        {
            await _adminService.AddAuthor(author);
            return RedirectToAction("AllAuthor");
        }

        public IActionResult DeleteAuthor(int id)
        {
            _adminService.DeleteAuthor(id);
            return RedirectToAction("AllAuthor");
        }
        public async Task<IActionResult> EditAuthor(int id)
        {
            var category = await _adminService.EditCategory(id);
            return View("EditAuthor", category);

        }
        public IActionResult UpdateAuthor(Author author)
        {
            _adminService.UpdateAuthor(author);
            return RedirectToAction("AllAuthor");
        }
        public async Task<IActionResult> AllUser()
        {
            var users = _adminService.AllUser();
            return View(users);
        }
        public IActionResult NewUser()
        {
            var role = ListUserRole();
            ViewBag.Roles = role;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Newuser(User user)
        {
            await _adminService.AddUser(user);
            return RedirectToAction("AllUser");
        }
        public IActionResult DeleteUser(int id)
        {
            _adminService.DeleteUser(id);
            return RedirectToAction("AllUser");
        }
        public async Task<IActionResult> EditUser(int id)
        {
            var items = ListUserRole();
            ViewBag.Roles=items;
            var user = await _adminService.EditUser(id);
            return View("EditUser", user);
        }

        public async Task<IActionResult> AllReservation()        {

            var reservations = _adminService.AllReservation();
            return View(reservations);
        }
        public IActionResult NewReservation()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation reservation)
        {
            await _adminService.AddReservation(reservation);
            return RedirectToAction("AllReservation");
        }
        public IActionResult DeleteReservation(int id)
        {
            _adminService.DeletReservation(id);
            return RedirectToAction("AllReservation");
        }
        public async Task<IActionResult> EditReservation(int id)
        {
            var reservation = await _adminService.EditReservation(id);
            return View("EditUser", reservation);

        }

        private List<SelectListItem> ListAuthor() // select box yapmak için.
        {
            var listAuthor = _adminService.AllAuthor();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in listAuthor)
            {
                items.Add(new SelectListItem { Text = item.AuthorName, Value = item.Id.ToString() });
            }
            return items;
        }
        private List<SelectListItem> ListCategory()
        {
            var listCategory = _adminService.AllCategory();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in listCategory)
            {
                items.Add(new SelectListItem { Text = item.CategoryName, Value = item.Id.ToString() });
            }
            return items;
        }

        private List<SelectListItem> ListUserRole()
        {
            string[] listRole =  { "Admin", "User" };
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var item in listRole)
            {
                items.Add(new SelectListItem { Text = item, Value = item.ToString() });
            }
            return items;
        }
        [HttpGet]
        public async Task<string> GetUser()
        {
            var claimTypes = HttpContext.User.Claims.ToList();
            var email = claimTypes[1].Value;
            var user = await _adminService.AdminFullName(email);
            return user;
        }

        public async Task<IActionResult> Quit()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("AllUser");
        }



    }
}
