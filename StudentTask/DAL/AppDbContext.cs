using Microsoft.EntityFrameworkCore;
using StudentTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTask.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions opt):base(opt)
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
