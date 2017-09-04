using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcBase.Models
{
    public class FakeModel
    {
        public int EmployeeID { get; set; }

        [Required(ErrorMessage ="Bir isim giriniz!")]
        public string Name { get; set; }

        public string Position { get; set; }

        [EmailAddress(ErrorMessage ="Gercek bir mail adresi giriniz!")]
        public string Email { get; set; }

        public Nullable<int> Salary { get; set; }
    }
}