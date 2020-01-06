using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        //TODO: get from entitiy framework db
        public static List<Customer> Customers { get; }

        static CustomersController()
        {
            Customers = new List<Customer> {
                new Customer {
                   Id = 1,  Name = "test customer"
            },
                new Customer{
                    Id = 2, Name = "second test customer"
                }
            };
        }


        // GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return Customers.Select(Mapper.Map<Customer, CustomerDto>);
        }

        // get /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            Customers.Add(customer);

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customer/1
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            Customers.Remove(customerInDb);
            Customers.Add(customer);
        }

        // DELETE /api/customer/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customer = Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Customers.Remove(customer);
        }
    }

}
