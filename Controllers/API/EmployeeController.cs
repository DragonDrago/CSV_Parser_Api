using CSV_Parser_Api.Models;
using CSV_Parser_Api.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CSV_Parser_Api.Controllers.API
{

    [Route("api/employee")]
    [Route("api/employee/{id}")]
    public class EmployeeController : ApiController
    {
        private ApplicationDbContext context;
        private CSV_Parser parser;
        public EmployeeController()
        {
            context = new ApplicationDbContext();
            parser = new CSV_Parser();
        }

        //GET/api/employee
        [HttpGet]
        public IHttpActionResult GetAllEmployees()
        {
            return Ok(context.Employees.ToList());
        }

        //GET/api/employee/1
        [HttpGet]
        public IHttpActionResult GetEmployee(int id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }


        [HttpPost]
        public IHttpActionResult Post()
        {
            var counter = new Counter(null);
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;
            if (file != null && file.ContentLength > 0)
            {
                var entities = parser.CsvParser(file);
                foreach (var entity in entities)
                {
                    context.Employees.Add(entity);
                    counter.Increment();
                }
                context.SaveChanges();
                return Ok(counter);
            }
            
            return BadRequest();
        }

        [HttpPut]
        public IHttpActionResult EditEmployee(int id, Employee employeeForUpdate)
        {
            var employeeInDb = context.Employees.FirstOrDefault(x => x.Id == id);
            if(employeeInDb == null || !ModelState.IsValid)
            {
                return BadRequest("The employee in Database is not exist or Model State is not valid!");
            }
            employeeInDb.StartDate = employeeForUpdate.StartDate;
            employeeInDb.Postcode = employeeForUpdate.Postcode;
            employeeInDb.DateOfBirth = employeeForUpdate.DateOfBirth;
            employeeInDb.Forenames = employeeForUpdate.Forenames;
            employeeInDb.Address = employeeForUpdate.Address;
            employeeInDb.Address2 = employeeForUpdate.Address2;
            employeeInDb.Surname = employeeForUpdate.Surname;
            employeeInDb.EmailHome = employeeForUpdate.EmailHome;
            employeeInDb.Telephone = employeeForUpdate.Telephone;
            employeeInDb.Mobile = employeeForUpdate.Mobile;
            employeeInDb.PayrollNumber = employeeForUpdate.PayrollNumber;
            context.SaveChanges();
            return Ok(employeeForUpdate);
        }

        [HttpDelete]
        public IHttpActionResult DeleteEmployee(int id)
        {
            var employee = context.Employees.FirstOrDefault(x => x.Id == id);
            if(employee == null)
            {
                return BadRequest();
            }
            context.Employees.Remove(employee);
            context.SaveChanges();
            return Ok("Object Successfully Deleted!");
        }
        
    }
}
