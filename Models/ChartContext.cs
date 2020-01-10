using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication3.Models
{
    public class ChartContext : DbContext
    {
        public DbSet<UserData> UserDatas { get; set; }
        public DbSet<Point> Points { get; set; }
    }
}