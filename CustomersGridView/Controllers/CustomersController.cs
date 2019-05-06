using CustomersGridView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomersGridView.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            CustomersGridViewEntities entities = new CustomersGridViewEntities();
            List<Customer> customers = entities.Customers.ToList();

            return View(customers.ToList());
        }
        // POST: Update Customer
        public ActionResult UpdateCustomer(Customer customer)
        {
            using (CustomersGridViewEntities entities = new CustomersGridViewEntities())
            {
                Customer updatedCustomer = (from c in entities.Customers where c.CustomerId == customer.CustomerId select c).FirstOrDefault();
                updatedCustomer.Name = customer.Name;
                updatedCustomer.Country = customer.Country;
                entities.SaveChanges();
            }
            return new EmptyResult();
        }
    }
}