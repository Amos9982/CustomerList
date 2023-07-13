using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerList.Models;
using CustomerList.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerList.Controllers
{
    public class CustomerController : Controller
    {

        private readonly ApplicationDbContext _db;

        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IEnumerable<Customer> objCustomerList = _db.Customers.ToList();
            return View(objCustomerList);
        }

        //Get
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer obj)
        {
            //Check if data is valid
            if (ModelState.IsValid) {
                obj.CreatedAt = DateTime.Now;//Get current datetime
                _db.Customers.Add(obj); //Add data
                _db.SaveChanges(); //Push and save to db
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Get
        public IActionResult Edit(int? id)
        {
            if(id == null || id ==0)
            {
                return NotFound();
            }
            var customerFromDb = _db.Customers.Find(id);

            if (customerFromDb == null)
            {
                return NotFound();
            }
            return View(customerFromDb);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer obj)
        {
            //Check if data is valid
            if (ModelState.IsValid)
            {
                _db.Customers.Update(obj); //Update data
                _db.SaveChanges(); //Push and save to db
                return RedirectToAction("Index");
            }


            return View(obj);
        }

        //Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var customerFromDb = _db.Customers.Find(id);

            if (customerFromDb == null)
            {
                return NotFound();
            }
            return View(customerFromDb);
        }

        //Post
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Customers.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Customers.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}