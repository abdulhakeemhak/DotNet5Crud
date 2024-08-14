using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

#nullable disable

namespace DotNet5Crud.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string EmployeeNumber { get; set; }
        public decimal BasicSalary { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        //public string ReligionId { get; set; }
        //public string ReligionName { get; set; }
        public string Religion { get; set; }
        public string Role { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
