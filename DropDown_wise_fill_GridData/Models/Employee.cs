using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDown_wise_fill_GridData
{
    public class Employee
    {
        public List<SelectListItem> ManagerEmployeeList { get; set; }
        public List<Employee> EmployeeTeamGrid { get; set; }
        public int Employee_ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Mobile { get; set; }
    }
}