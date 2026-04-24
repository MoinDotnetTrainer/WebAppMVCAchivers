using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProjectLibrary.Models
{
    public class AppDb : DbContext // connection base class ef core
    {
        public AppDb(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Users> Users { get; set; } //table
        public DbSet<Orders> Orders { get; set; } //table
        public DbSet<Movies> Movies { get; set; } //table
    }
}
