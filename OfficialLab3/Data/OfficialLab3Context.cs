#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficialLab3.Models;

namespace OfficialLab3.Data
{
    public class OfficialLab3Context : DbContext
    {
        public OfficialLab3Context (DbContextOptions<OfficialLab3Context> options)
            : base(options)
        {
        }

        public DbSet<OfficialLab3.Models.Student> Student { get; set; }

        public DbSet<OfficialLab3.Models.Course> Course { get; set; }

        public DbSet<OfficialLab3.Models.Staff> Staff { get; set; }

        public DbSet<OfficialLab3.Models.Teacher> Teacher { get; set; }
    }
}
