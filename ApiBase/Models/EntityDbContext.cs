using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApiBase.Models
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext():base("name=MyConStr")
        {

        }
        public virtual DbSet<Employee> Emplooyes { get; set; }
    }
}