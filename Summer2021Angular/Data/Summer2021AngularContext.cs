using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Summer2021Angular.Models.Courses;

namespace Summer2021Angular.Data
{
    public class Summer2021AngularContext : DbContext
    {
        public Summer2021AngularContext (DbContextOptions<Summer2021AngularContext> options)
            : base(options)
        {
        }

        public DbSet<Summer2021Angular.Models.Courses.Course> Course { get; set; }

        public DbSet<Summer2021Angular.Models.Courses.Notebook> Notebook { get; set; }

        public DbSet<Summer2021Angular.Models.Courses.File> File { get; set; }
    }
}
