using ADO.NET.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using DataTable = System.Data.DataTable;

namespace ADO.NET.Controllers
{
    public class ProductController : Controller
    {
        private readonly SqlConnection _con;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable = new DataTable();
        // GET: ProductController

        public ProductController()
        {
            _con = new SqlConnection("Server = (localdb)\\mssqllocaldb; Database = MvcMovieContext - 1; Trusted_Connection = True; MultipleActiveResultSets = true");
            _con.Open();
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            dataAdapter = new SqlDataAdapter("select * from product",_con);
            dataAdapter.Fill(dataTable);
            foreach (DataRow row in dataTable.Rows)
            {
                products.Add(new Product
                {
                    Id = Convert.ToInt32(row["id"]),
                    FirstName = Convert.ToString(row["name"]),
                    LastName = Convert.ToString(row["name"]),
                    City = Convert.ToString(row["name"]),



                });
            }
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            Product product = GetProducts()[id];
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult create([Bind("Id,FirstName,LastName,City")] ProductController product)
        {
            if (ModelState.IsValid)
            {
                dataAdapter = new SqlDataAdapter($"INSERT IN TO Product" Values,(firstName'{product .firstname}'
                    , lastName'{product.lastname}');

            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return Delete(id, _con);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SqlConnection _con)
        {
            dataAdapter = new SqlDataAdapter($"DELETE FRPM Product WHERE id={id}" _con);
            dataAdapter.Fill(dataTable);
            return RedirectToAction(nameof(Index));
            
        }
    }
}
