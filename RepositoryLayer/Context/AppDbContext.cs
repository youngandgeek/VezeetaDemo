using DomainLayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    //for database connection 
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        //constructor
        public AppDbContext() : base()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options)
       : base(options)
        {
        }


        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

      
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Add the roles by calling the SeedRole method
            SeedRoles(builder);


            // Add any custom configurations or constraints here

            // Example: Configure a one-to-one relationship between ApplicationUser and Patient
            //PatientProfile from the refrence of Patient in ApplicationUser
            builder.Entity<ApplicationUser>()
                .HasOne(p => p.PatientProfile)
                .WithOne()
                .HasForeignKey<Patient>(p => p.Id);

         
            // Example: Configure a one-to-one relationship between ApplicationUser and Doctor
            builder.Entity<ApplicationUser>()
                .HasOne(d => d.DoctorProfile)
                .WithOne()
                .HasForeignKey<Doctor>(d => d.Id);

            // Configure a one-to-many relationship between Doctor and Appointments
/**            builder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctors)
                .HasForeignKey(a => a.Id);

          // Configure a one-to - many relationship between Doctor and Bookings
           builder.Entity<Doctor>()
        .HasMany(d => d.Bookings)
        .WithOne(b => b.DoctorInfo)
        .HasForeignKey(b => b.DoctorId);

            // Configure a one-to-many relationship between Patient and Bookings
            builder.Entity<Patient>()
                .HasMany(p => p.Bookings)
                .WithOne(b => b.Patientinfo)
                .HasForeignKey(b => b.PatientId);
   **/
            }



        //Add Roles to the AspNetUserRole default dentity table
        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Name = "Admin",
                    //helps prevent conflicts by ensuring that updates are applied only if the entity's concurrency stamp matches
                    ConcurrencyStamp = "1",
                    //NormalizedName is used to support case-insensitive searches and comparisons for role names.
                    NormalizedName = "Admin"
                },

                new IdentityRole()
                {
                    Name = "Patient",
                    ConcurrencyStamp = "2",
                    NormalizedName = "Patient"
                }
                ,

                    new IdentityRole()
                    {
                        Name = "Doctor",
                        ConcurrencyStamp = "3",
                        NormalizedName = "Doctor"
                    }
                    );

        }

    }

}
