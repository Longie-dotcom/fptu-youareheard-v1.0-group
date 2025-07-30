using BussinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class PatientProfileDAO
    {
        public static List<PatientProfile> GetAllProfiles()
        {
            List<PatientProfile> profiles = new List<PatientProfile>();

            try
            {
                using (var context = new YouAreHeardContext())
                {
                    profiles = context.PatientProfiles.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return profiles;
        }

        public static void UpdateHivStatus(int userId, int hivStatusId)
        {
            try
            {
                using var context = new YouAreHeardContext();
                var profile = context.PatientProfiles.Find(userId);
                if (profile != null)
                {
                    profile.HivStatusId = hivStatusId;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating HIV status: " + ex.Message);
            }
        }

        public static PatientProfile GetProfileByUserId(int userId)
        {
            PatientProfile profile = null;

            try
            {
                using (var context = new YouAreHeardContext())
                {
                    profile = context.PatientProfiles.FirstOrDefault(p => p.UserId == userId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return profile;
        }

        public static void AddProfile(PatientProfile profile)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    context.PatientProfiles.Add(profile);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateProfile(PatientProfile profile)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var existing = context.PatientProfiles.Find(profile.UserId);

                    if (existing != null)
                    {
                        existing.HivStatusId = profile.HivStatusId;
                        existing.PregnancyStatusId = profile.PregnancyStatusId;
                        existing.Height = profile.Height;
                        existing.Weight = profile.Weight;
                        existing.Gender = profile.Gender;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteProfile(int userId)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var profile = context.PatientProfiles.Find(userId);

                    if (profile != null)
                    {
                        context.PatientProfiles.Remove(profile);
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
