using gDMS.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gDMS.Web.Data
{
    public class DmsDbContext: DbContext
    {
        public DmsDbContext():base("DmsDbContext") { }

        public DbSet<Doctor> Doctors { get; set; }
    }
}