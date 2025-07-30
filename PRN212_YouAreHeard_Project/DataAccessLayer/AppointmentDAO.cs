using System;
using System.Collections.Generic;
using System.Linq;
using BussinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class AppointmentDAO
    {
        public static List<Appointment> GetAllAppointmentsWithDetails()
        {
            List<Appointment> appointments = new List<Appointment>();

            try
            {
                using (var context = new YouAreHeardContext())
                {
                    appointments = context.Appointments
                        .Include(a => a.DoctorSchedule)
                        .Include(a => a.Patient)
                            .ThenInclude(p => p.PatientProfile)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return appointments;
        }

        public static List<Appointment> GetAllAppointments()
        {
            List<Appointment> appointments = new List<Appointment>();

            try
            {
                using (var context = new YouAreHeardContext())
                {
                    appointments = context.Appointments.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return appointments;
        }

        public static Appointment GetAppointmentById(int id)
        {
            Appointment appointment = null;

            try
            {
                using (var context = new YouAreHeardContext())
                {
                    foreach (var a in context.Appointments)
                    {
                        if (a.AppointmentId == id)
                        {
                            appointment = a;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return appointment;
        }


        public static Appointment GetAppointmentByOrderCode(string orderCode)
        {
            try
            {
                using var context = new YouAreHeardContext();
                var appointment = context.Appointments
                    .Include(a => a.Doctor)
                    .Include(a => a.DoctorSchedule)
                    .Include(a => a.Patient)
                    .ThenInclude(p => p.PatientProfile)
                    .FirstOrDefault(a => a.OrderCode == orderCode);
                return appointment;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public static void AddAppointment(Appointment appointment)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    context.Appointments.Add(appointment);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateAppointment(Appointment appointment)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var existingAppointment = context.Appointments.Find(appointment.AppointmentId);

                    if (existingAppointment != null)
                    {
                        existingAppointment.DoctorId = appointment.DoctorId;
                        existingAppointment.PatientId = appointment.PatientId;
                        existingAppointment.DoctorScheduleId = appointment.DoctorScheduleId;
                        existingAppointment.AppointmentStatusId = appointment.AppointmentStatusId;
                        existingAppointment.ZoomLink = appointment.ZoomLink;
                        existingAppointment.Notes = appointment.Notes;
                        existingAppointment.DoctorNotes = appointment.DoctorNotes;
                        existingAppointment.Reason = appointment.Reason;
                        existingAppointment.IsAnonymous = appointment.IsAnonymous;
                        existingAppointment.IsOnline = appointment.IsOnline;
                        existingAppointment.QueueNumber = appointment.QueueNumber;
                        existingAppointment.OrderCode = appointment.OrderCode;
                        existingAppointment.Date = appointment.Date;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteAppointment(int id)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var appointment = context.Appointments.Find(id);

                    if (appointment != null)
                    {
                        context.Appointments.Remove(appointment);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
