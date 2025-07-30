using System;
using System.Linq;
using BussinessObjects;
using Enums;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class AdminDAO
    {
        public static int GetTotalUserCount()
        {
            try
            {
                using var _context = new YouAreHeardContext();
                return _context.Users.Count();
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting users: " + ex.Message);
            }
        }

        public static int GetTotalDoctorCount()
        {
            try
            {
                using var _context = new YouAreHeardContext();
                return _context.DoctorProfiles.Count();
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting doctors: " + ex.Message);
            }
        }

        public static int GetTotalPatientCount()
        {
            try
            {
                using var _context = new YouAreHeardContext();
                return _context.PatientProfiles.Count();
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting patients: " + ex.Message);
            }
        }

        public static int GetTotalAppointmentCount()
        {
            try
            {
                using var _context = new YouAreHeardContext();
                return _context.Appointments.Count();
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting appointments: " + ex.Message);
            }
        }

        public static int GetActiveTreatmentPlanCount()
        {
            try
            {
                using var _context = new YouAreHeardContext();
                return _context.TreatmentPlans.Count(); // Optionally filter for active plans
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting treatment plans: " + ex.Message);
            }
        }

        public static int GetTotalLabResultCount()
        {
            try
            {
                using var _context = new YouAreHeardContext();
                return _context.LabResults.Count();
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting lab results: " + ex.Message);
            }
        }

        public static int GetConfirmedAppointmentCount()
        {
            try
            {
                using var _context = new YouAreHeardContext();
                return _context.Appointments
                    .Count(a => a.AppointmentStatusId == AppointmentStatusEnum.CONFIRMED);
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting confirmed appointments: " + ex.Message);
            }
        }

        public static int GetCompletedAppointmentCount()
        {
            try
            {
                using var _context = new YouAreHeardContext();
                return _context.Appointments
                    .Count(a => a.AppointmentStatusId == AppointmentStatusEnum.COMPLETE);
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting completed appointments: " + ex.Message);
            }
        }

        public static int GetCancelledAppointmentCount()
        {
            try
            {
                using var _context = new YouAreHeardContext();
                return _context.Appointments
                    .Count(a => a.AppointmentStatusId == AppointmentStatusEnum.CANCEL);
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting cancelled appointments: " + ex.Message);
            }
        }

        public static int GetPendingAppointmentCount()
        {
            try
            {
                using var _context = new YouAreHeardContext();
                return _context.Appointments
                    .Count(a => a.AppointmentStatusId == AppointmentStatusEnum.PENDING);
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting pending appointments: " + ex.Message);
            }
        }

        public static int GetTotalVerifiedAccount()
        {
            try
            {
                using var _context = new YouAreHeardContext();
                return _context.Otpverifications
                    .Count(o => o.IsVerified == true);
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting pending appointments: " + ex.Message);
            }
        }

        public static int GetTotalUnverifiedAccount()
        {
            try
            {
                using var _context = new YouAreHeardContext();
                return _context.Otpverifications
                    .Count(o => o.IsVerified == false);
            }
            catch (Exception ex)
            {
                throw new Exception("Error counting pending appointments: " + ex.Message);
            }
        }
    }
}
