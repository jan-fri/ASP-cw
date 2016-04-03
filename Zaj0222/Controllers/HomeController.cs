using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zaj0222.Models;

namespace Zaj0222.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var context = new NorthwindModel())
            {
                return View(context.Customers.ToArray());
            }
        }

        public ActionResult Edit(string id)
        {
            using (var context = new NorthwindModel())
            {
                var customer = context.Customers.FirstOrDefault(x => x.CustomerID == id);
                if (customer !=null)
                {
                    return View(customer);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

        }

        [HttpPost]
        public ActionResult Edit(Customers customer)
        {
            if (ModelState.IsValid) //validacja!!!!!!
            {
                using (var context = new NorthwindModel())
                {
                    var dbCustomer = context.Customers.FirstOrDefault(x => x.CustomerID == customer.CustomerID);

                    if (dbCustomer != null)
                    {
                        dbCustomer.CompanyName = customer.CompanyName;
                        dbCustomer.ContactName = customer.ContactName;
                        dbCustomer.City = customer.City;
                        //..
                        context.SaveChanges();
                    }

                     return HttpNotFound();

                }
            }
            return View(customer);
        }
    }
}