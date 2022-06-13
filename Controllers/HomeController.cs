using CSV_Parser_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSV_Parser_Api.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext applicationDbContext;
        public HomeController()
        {
            applicationDbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
           var employees =  applicationDbContext.Employees.ToList();
            return View(employees);
        }

        public ActionResult Edit(int id)
        {
            var employee = applicationDbContext.Employees.SingleOrDefault(x => x.Id == id);
            if(employee == null)
            {
                return View("NotFound");
            }
            var response = new Employee()
            {
                Id = employee.Id,
                Telephone = employee.Telephone,
                Address = employee.Address,
                Address2 = employee.Address2,
                PayrollNumber = employee.PayrollNumber,
                EmailHome = employee.EmailHome,
                DateOfBirth = employee.DateOfBirth,
                StartDate = employee.StartDate,
                Surname = employee.Surname,
                Forenames = employee.Forenames,
                Postcode = employee.Postcode,
                Mobile = employee.Mobile
            };
            return View(response);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}