using KütüphaneTakip.Business.Services;
using KütüphaneTakip.Core.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KütüphaneTakip.Web.Controllers
{
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
        public async Task<IActionResult> AllBooks()
        {

            var list = _adminService.AllBooks();
            return View(list);
        }

        public IActionResult NewBook()
        {
            var items = ListAuthor();
            var category = ListCategory();
            ViewBag.Authors=items;
            ViewBag.Categories=category;
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewBook(Book book)
        {
            await _adminService.AddBook(book);
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
            return View("EditCategory",category);
                
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

        private  List<SelectListItem> ListAuthor() // select box yapmak için.
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
        


    }
}
