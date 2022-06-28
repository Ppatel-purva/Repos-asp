using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web3.Controllers
{
    public class CoffeeController1 : Controller
    {
        // GET: CoffeeController1
        public ActionResult Index()
        {
            return View();
        }

        // GET: CoffeeController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CoffeeController1/Create 
        public ActionResult Create()
        {
            return View();
        }

        // POST: CoffeeController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoffeeController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CoffeeController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CoffeeController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CoffeeController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
