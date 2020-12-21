using MVC_EF_CRUD_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_EF_CRUD_PostgreSQL.DataContext1
{
    public class ApplicationDbContext1: DbContext
    {
        public ApplicationDbContext1() : base(nameOrConnectionString: "Myconnection")
        {

        }
        public virtual DbSet<StudentClass>students { get; set; }

    }

   
}