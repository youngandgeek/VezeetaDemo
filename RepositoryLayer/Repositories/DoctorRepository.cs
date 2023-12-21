﻿using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VezeetaDemo.RepositoryLayer;

namespace RepositoryLayer
{
    internal class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Login(string email, string password)
        {
            // Implement login logic based on your requirements
            // For example, check credentials against the database
            var doctor = _context.Doctors.FirstOrDefault(d => d.DoctorUser.Email == email);

            if (doctor != null)
            {
                // Validate password here
                // Example: if (PasswordHashing.ValidatePassword(password, doctor.DoctorUser.PasswordHash))
                // {
                //     return true;
                // }
            }

            return false;
        }

        public List<Patient> GetAllBooking(DateTime searchDate, int pageSize, int pageNumber)
        {
            // Implement logic to get a list of patients with bookings based on search criteria
            var patients = _context.Patients
                .Include(p => p.Bookings)
                .ThenInclude(b => b.Appointment) // Include appointments if needed
                .Where(p => p.IsActive)          // Add any filtering conditions
                .ToList();

            return patients;
        }

        public bool ConfirmCheckup(int bookingId)
        {
            try
            {
                var booking = _context.Bookings.FirstOrDefault(b => b.Id == bookingId);

                if (booking != null)
                {
                    // Implement confirmation logic here
                    // For example: booking.IsConfirmed = true;

                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (log, throw, etc.)
                return false;
            }
        }

        public bool AddAppoinment(Appointment appointment)
        {
            try
            {
                // Implement logic to add a new appointment to the database
                _context.Appointments.Add(appointment);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (log, throw, etc.)
                return false;
            }
        }

        public bool UpdateAppoinment(int appointmentId, string newTime)
        {
            try
            {
                var appointment = _context.Appointments.FirstOrDefault(a => a.Id == appointmentId);

                if (appointment != null)
                {
                    // Implement update logic here
                    // For example: appointment.Time = newTime;

                    _context.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (log, throw, etc.)
                return false;
            }
        }

        public bool DeleteAppoinment(int appointmentId)
        {
            try
            {
                var appointment = _context.Appointments.FirstOrDefault(a => a.Id == appointmentId);

                if (appointment != null)
                {
                    // Implement delete logic here
                    _context.Appointments.Remove(appointment);
                    _context.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (log, throw, etc.)
                return false;
            }
        }
    }
}