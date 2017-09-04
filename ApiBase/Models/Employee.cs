using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiBase.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public string Email { get; set; }

        public Nullable<int>  Salary { get; set; }

    }
}