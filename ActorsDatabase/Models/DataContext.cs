using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ActorsDatabase.Models
{
    public class DataContext : DbContext
    {
        public DataContext(): base("conn") { }
        public DbSet<Actors> Actors { get; set; }
    }
}