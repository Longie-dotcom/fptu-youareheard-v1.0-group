using BussinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class DoctorScheduleDAO
    {
        public static List<DoctorSchedule> GetAllSchedules()
        {
            List<DoctorSchedule> schedules = new List<DoctorSchedule>();

            try
            {
                using (var context = new YouAreHeardContext())
                {
                    schedules = context.DoctorSchedules.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return schedules;
        }

        public static DoctorSchedule GetScheduleById(int id)
        {
            DoctorSchedule schedule = null;

            try
            {
                using (var context = new YouAreHeardContext())
                {
                    schedule = context.DoctorSchedules.FirstOrDefault(s => s.DoctorScheduleId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return schedule;
        }

        public static void AddSchedule(DoctorSchedule schedule)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    context.DoctorSchedules.Add(schedule);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateSchedule(DoctorSchedule schedule)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var existing = context.DoctorSchedules.Find(schedule.DoctorScheduleId);

                    if (existing != null)
                    {
                        existing.UserId = schedule.UserId;
                        existing.Location = schedule.Location;
                        existing.StartTime = schedule.StartTime;
                        existing.EndTime = schedule.EndTime;
                        existing.DoctorScheduleStatusId = schedule.DoctorScheduleStatusId;
                        existing.Date = schedule.Date;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static List<DoctorSchedule> GetSchedulesByDoctorId(int doctorId)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    return context.DoctorSchedules
                        .Include(s => s.User) // Loads related DoctorProfile
                        .Include(s => s.DoctorScheduleStatus) // Loads related schedule status
                        .Include(s => s.Appointments) // Optional: loads related appointments
                        .Where(s => s.UserId == doctorId)
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving schedules: " + ex.Message);
            }
        }

        public static void DeleteSchedule(int id)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var schedule = context.DoctorSchedules.Find(id);

                    if (schedule != null)
                    {
                        context.DoctorSchedules.Remove(schedule);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void AddDoctorScheduleRange(List<DoctorSchedule> list)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    context.DoctorSchedules.AddRange(list);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
