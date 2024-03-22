using Microsoft.AspNetCore.Mvc;
using SimpleCRUDApp.Data;
using SimpleCRUDApp.Models;

namespace SimpleCRUDApp.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _database;

        public ItemController(ApplicationDbContext applicationDbContext)
        {
            _database = applicationDbContext;
        }

        public IActionResult Index()
        {
            List<Item> items = _database.Items.ToList();
            return View(items);
        }
    }
}
