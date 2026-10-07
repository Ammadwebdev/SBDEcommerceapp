using Microsoft.AspNetCore.Mvc;
using SBDEcommerceapp.Data;
using SBDEcommerceapp.Models;

namespace SBDEcommerceAPI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();

            return View(categories);
        }
    




public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
                ModelState.AddModelError("name", "The name cannot match the display order");

            if (obj.Name?.ToLower() == "test")
                ModelState.AddModelError("", "Test is an invalid value");

            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully!";
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = _db.Categories.Find(id); // ✅ FIX HERE

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
                ModelState.AddModelError("name", "The name cannot match the display order");

            if (obj.Name?.ToLower() == "test")
                ModelState.AddModelError("", "Test is an invalid value");

            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = _db.Categories.Find(id);
            if (category == null)
                return NotFound();

            return View(category);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
                return NotFound();

            var category = _db.Categories.Find(id);
            if (category == null)
                return NotFound();

            _db.Remove(category);
            _db.SaveChanges();

            TempData["success"] = "Category deleted successfully!";
            return RedirectToAction("Index");
        }





    }
}
