using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DropDown_wise_fill_GridData.DBModels;

namespace DropDown_wise_fill_GridData.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDBEntities db = new EmployeeDBEntities();

        // GET: Employee
        public ActionResult Index()
        {
            Employee _model = new Employee();
            var ManagerList = db.EmployeeTeam.ToList().Where(a => a.IsManager.Equals(true));

            _model.ManagerEmployeeList = (from d in ManagerList
                                          select new SelectListItem
                                          {
                                              Value = d.Employee_ID.ToString(),
                                              Text = d.Name
                                          }).ToList();

            var qq = (from e in db.EmployeeTeam
                      select new Employee
                      {
                          Employee_ID = e.Employee_ID,
                          Name = e.Name,
                          Email = e.Email,
                          Country = e.Country,
                          Mobile = e.Mobile
                      }).ToList();

            _model.EmployeeTeamGrid = qq;
            return View("Index", _model);
        }
        public ActionResult Filter(int Manager_ID)
        {
            int? emp_ID = Convert.ToInt32(Manager_ID);
            List<Employee> y = null;
            var qq = y;
            if (emp_ID == 0)
            {
                qq = (from e in db.EmployeeTeam
                      select new Employee
                      {
                          Employee_ID = e.Employee_ID,
                          Name = e.Name,
                          Email = e.Email,
                          Country = e.Country,
                          Mobile = e.Mobile
                      }).ToList();
            }
            else
            {
                qq = (from e in db.EmployeeTeam
                      where e.Manager_ID == emp_ID
                      select new Employee
                      {
                          Employee_ID = e.Employee_ID,
                          Name = e.Name,
                          Email = e.Email,
                          Country = e.Country,
                          Mobile = e.Mobile
                      }).ToList();
            }
            return PartialView("_ShowManagerTeam", qq);
        }
    }
}