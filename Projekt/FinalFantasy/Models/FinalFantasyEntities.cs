using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalFantasy.Models
{
    public class FinalFantasyEntities : DbContext
    {
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Site> Sites { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}