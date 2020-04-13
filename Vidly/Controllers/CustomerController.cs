using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.EntityFramework;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        private Context _context;

        public CustomerController()
        {
            _context = new Context();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose(disposing);
        }
        static CustomerController()
        {
        }
                
        // GET: Customer
        public ActionResult Index()
        {
            return View(_context.Customers.Include(c => c.MembershipType).ToList());
        }

        // GET: Customer/CustomerDetails
        public ActionResult CustomerDetails(int id)
        {
            Customer model = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (model == null)
                return HttpNotFound();

            return View(model);
        }
    }
}