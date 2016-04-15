using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zaj0222.Models;
using Zaj0222.ViewModel;

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
        [HttpGet]
        public ActionResult Edit(string id)
        {
            using (var context = new NorthwindModel())
            {
                var customer = context.Customers.FirstOrDefault(x => x.CustomerID == id);
                if (customer !=null)
                {
                    var viewModel = Mapper.Map<CustomerViewModel>(customer);
                    return View(viewModel);
                }                
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerViewModel viewModel)
        {
            if (ModelState.IsValid) //validacja!!!!!!
            {
                using (var context = new NorthwindModel())
                {
                    var customer = context.Customers.FirstOrDefault(x => x.CustomerID == viewModel.CustomerID);
                    if (customer != null)
                    {
                        Mapper.Map(viewModel, customer);
                        context.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
            }
            return View(viewModel);
        }
    }
}