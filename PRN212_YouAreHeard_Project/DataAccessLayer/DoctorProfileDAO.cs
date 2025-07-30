using System;
using System.Collections.Generic;
using System.Linq;
using BussinessObjects;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    public class DoctorProfileDAO
    {
        public static List<DoctorProfile> GetAllDoctors()
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    return context.DoctorProfiles
                                  .Include(d => d.User) // <-- include related User
                                  .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting all doctors: " + ex.Message);
            }
        }

        public static DoctorProfile? GetDoctorById(int userId)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    return context.DoctorProfiles.FirstOrDefault(d => d.UserId == userId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting doctor by ID: " + ex.Message);
            }
        }

        public static void AddDoctor(DoctorProfile doctor)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    context.DoctorProfiles.Add(doctor);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding doctor: " + ex.Message);
            }
        }

        public static void UpdateDoctor(DoctorProfile doctor)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var existing = context.DoctorProfiles.FirstOrDefault(d => d.UserId == doctor.UserId);
                    if (existing != null)
                    {
                        existing.Specialties = doctor.Specialties;
                        existing.YearsOfExperience = doctor.YearsOfExperience;
                        existing.Image = doctor.Image;
                        existing.Gender = doctor.Gender;
                        existing.Description = doctor.Description;
                        existing.LanguagesSpoken = doctor.LanguagesSpoken;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating doctor: " + ex.Message);
            }
        }

        public static void DeleteDoctor(int userId)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var doctor = context.DoctorProfiles.FirstOrDefault(d => d.UserId == userId);
                    if (doctor != null)
                    {
                        context.DoctorProfiles.Remove(doctor);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting doctor: " + ex.Message);
            }
        }

        public static void AddDoctorWithContext(DoctorProfile doctor, DataAccessLayer.YouAreHeardContext context)
        {
            try
            {
                context.DoctorProfiles.Add(doctor);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding doctor: " + ex.Message);
            }
        }
    }
}
