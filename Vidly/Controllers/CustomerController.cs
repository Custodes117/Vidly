using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        public static CustomerViewModel CustomersVm { get; private set; }

        static CustomerController()
        {
            CustomersVm = new CustomerViewModel()
            {
                Customers = new List<Customer>
             {
                 new Customer{ Name = "Customer 1", Id = 1},
                new Customer{ Name = "Customer 2", Id = 2}
             }
            };
        }
                
        // GET: Customer
        public ActionResult Index()
        {
            return View(CustomersVm);
        }

        // GET: Customer/CustomerDetails
        public ActionResult CustomerDetails(int id)
        {
            //TODO: show "Not found"
            return View(CustomersVm.Customers.FirstOrDefault(c => c.Id == id));
        }
    }
}