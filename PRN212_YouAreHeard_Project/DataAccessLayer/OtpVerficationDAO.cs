using System;
using System.Collections.Generic;
using System.Linq;
using BussinessObjects;

namespace DataAccessLayer
{
    public class OtpverificationDAO
    {
        public static List<Otpverification> GetAllOtps()
        {
            try
            {
                using var context = new YouAreHeardContext();
                return context.Otpverifications.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting OTPs: " + ex.Message);
            }
        }

        public static Otpverification? GetOtpById(int otpId)
        {
            try
            {
                using var context = new YouAreHeardContext();
                return context.Otpverifications.FirstOrDefault(o => o.Otpid == otpId);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting OTP by ID: " + ex.Message);
            }
        }

        public static void AddOtp(Otpverification otp)
        {
            try
            {
                using var context = new YouAreHeardContext();
                context.Otpverifications.Add(otp);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding OTP: " + ex.Message);
            }
        }

        public static void UpdateOtp(Otpverification otp)
        {
            try
            {
                using var context = new YouAreHeardContext();
                var existing = context.Otpverifications.FirstOrDefault(o => o.Otpid == otp.Otpid);
                if (existing != null)
                {
                    existing.Otp = otp.Otp;
                    existing.Email = otp.Email;
                    existing.ExpiredDate = otp.ExpiredDate;
                    existing.IsVerified = otp.IsVerified;

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating OTP: " + ex.Message);
            }
        }
        
        public static Otpverification? GetOtpByEmailAndOtp(string email, string otp)
        {
            try
            {
                using var context = new YouAreHeardContext();
                return context.Otpverifications
                    .FirstOrDefault(o => o.Email == email && o.Otp == otp);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting OTP by Email and OTP: " + ex.Message);
            }
        }

        public static void DeleteOtp(int otpId)
        {
            try
            {
                using var context = new YouAreHeardContext();
                var otp = context.Otpverifications.FirstOrDefault(o => o.Otpid == otpId);
                if (otp != null)
                {
                    context.Otpverifications.Remove(otp);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting OTP: " + ex.Message);
            }
        }

        public static void AddOtpWithContext(Otpverification otp, DataAccessLayer.YouAreHeardContext context)
        {
            try
            {
                context.Otpverifications.Add(otp);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding OTP with context: " + ex.Message);
            }
        }
    }
}
