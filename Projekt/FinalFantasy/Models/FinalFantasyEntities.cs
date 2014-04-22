using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalFantasy.Models
{
    public class FinalFantasyEntities : DbContext
    {
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Site> Site { get; set; }
    }
}