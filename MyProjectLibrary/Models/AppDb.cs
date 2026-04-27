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

        public DbSet<Aadhar> Aadhar { get; set; }  // Aadhar  // develps

        // In db Tbl_Aadhar

        public DbSet<Pan> Pan { get; set; }  // Pan



        public DbSet<Person> Person { get; set; }  // Pan
        public DbSet<Passport> Passport { get; set; }  // Pan
        public DbSet<Citizen> Citizen { get; set; }  // Pan
        public DbSet<Voters> Voters { get; set; }  // Pan
        public DbSet<Country> Country { get; set; }  // Pan
        public DbSet<State> State { get; set; }  // Pan
       

    }
}
