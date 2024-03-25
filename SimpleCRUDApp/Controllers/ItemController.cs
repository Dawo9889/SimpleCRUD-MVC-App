using Microsoft.AspNetCore.Mvc;
using SimpleCRUDApp.Data;
using SimpleCRUDApp.Models;
using System.Net;

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


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            if(ModelState.IsValid) 
            { 
                _database.Items.Add(item);
                _database.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(item);
        }


        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound(id);
            }
            Item? itemFromDatabase = _database.Items.FirstOrDefault(x => x.Id == id);
            if(itemFromDatabase == null)
            {
                return NotFound(id);
            }
            return View(itemFromDatabase);
        }
        [HttpPost, ActionName("Edit")]
        public IActionResult EditPOST(Item item)
        {
            if (ModelState.IsValid)
            {
                _database.Items.Update(item);
                _database.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(id);
            }
            Item? itemFromDatabase = _database.Items.FirstOrDefault(x => x.Id == id);
            if (itemFromDatabase == null)
            {
                return NotFound(id);
            }
            return View(itemFromDatabase);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Item? itemFromDb = _database.Items.Where(x => x.Id == id).FirstOrDefault();
            if (itemFromDb == null)
            {
                return NotFound(id);
            }
            _database.Items.Remove(itemFromDb);
            _database.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
