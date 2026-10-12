using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DoomsdayArmadurasMvc.Models
{
    public class DoomsdayDbContext : DbContext
    {
        public DoomsdayDbContext() : base("name=DoomsdayDbContext") { }

        public DbSet<Reino> Reinos { get; set; }
        public DbSet<Armadura> Armaduras { get; set; }
    }
}