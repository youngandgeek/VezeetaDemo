using DomainLayer.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Context
{
    //for database connection 
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public AppDbContext()
        {
        }

     

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<IdentityRole>().HasData(new IdentityRole {
                Id = "1", // Use the actual ID
                Name = "admin", NormalizedName = "admin".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "2", // Use the actual ID
                Name = "patient", NormalizedName = "patient".ToUpper() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole {Id = "3", Name = "doctor", NormalizedName = "doctor".ToUpper() });



            // Seed admin user
            var adminUser = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "vezeeta",
                UserName = "Admin@vezeeta.com",
                Email = "Admin@vezeeta.com",
                Phone = "1234567890",
                // Add any additional properties you may have in your ApplicationUser model
            };

            var hasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");

            builder.Entity<ApplicationUser>().HasData(adminUser);

            // Assign the admin user to the 'admin' role
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = adminUser.Id, RoleId = "1" }
            // Add other user roles as needed
            );

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




    }
    }
