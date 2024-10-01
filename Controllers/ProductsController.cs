using ABCretail2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCretail2.Controllers
{
    public class ProductsController : Controller
    {
        // This is a placeholder for data access; replace with your actual data source
        private static List<Product> _products = new List<Product>();

        // GET: Products
        public IActionResult Index()
        {
            // Return a view that lists all products
            return View(_products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public IActionResult Create(Product model)
        {
            if (ModelState.IsValid)
            {
                // Simulate adding the product to the database
                model.Id = _products.Count + 1; // Simple ID assignment
                _products.Add(model);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Products/Edit/5
        public IActionResult Edit(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, Product model)
        {
            if (ModelState.IsValid)
            {
                var product = _products.FirstOrDefault(p => p.Id == id);
                if (product == null)
                {
                    return NotFound();
                }

                // Update the product
                product.Name = model.Name;
                product.Price = model.Price;

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Products/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }

            return RedirectToAction("Index");
        }
    }
}
