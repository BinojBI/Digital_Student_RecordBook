using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentMgt.Models
{
    public class StudentMgtContext : DbContext
    {
        public StudentMgtContext (DbContextOptions<StudentMgtContext> options)
            : base(options)
        {
        }

        public DbSet<StudentMgt.Models.Marks> Marks { get; set; }
        public DbSet<StudentMgt.Models.Student_details> Student_details { get; set; }
    }
}
