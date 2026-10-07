using Microsoft.AspNetCore.Mvc;
using SBDEcommerceapp.Data;
using SBDEcommerceapp.Models;

namespace SBDEcommerceapp.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Product> ObjProductList = _db.Products.ToList();
            return View(ObjProductList);
        }

        public IActionResult Create()
        {
            return View(new Product()); // ✅ FIXED
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj) // ✅ FIXED
        {
            if (ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Product created successfully!";
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // ===================== EDIT =====================

        // GET: Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Products.Find(id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }


        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // ===================== DELETE =====================

        // GET: Delete (confirmation page)
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var productFromDb = _db.Products.Find(id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }


        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var productFromDb = _db.Products.Find(id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            _db.Products.Remove(productFromDb);
            _db.SaveChanges();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClearTitle(int id)
        {
            var product = _db.Products.Find(id); if (product == null)
                return NotFound();

            product.Title = string.Empty;
            product.Description = string.Empty;

            _db.Update(product);
            _db.SaveChanges();

            TempData["success"] = "Product title cleared!";
            return RedirectToAction("Index");
        }

    }
}