using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PegassusBooking.Models;

namespace PegassusBooking.Repositories
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=localhost;user=root;password=Qw@rty8457;database=PBWebsite";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
            //8.0.35 MySQL Community Server - GPL
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<MedicalReport> MedicalReports { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Room> Rooms { get; set; }

    }
}
