using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Web;


namespace WaterTracker.Models
{
    public class TrackersContext : DbContext
    {
        public DbSet<Tracker> Tracker { get; set; }
    }
}