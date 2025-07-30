using System;
using System.Collections.Generic;
using System.Linq;
using BussinessObjects;

namespace DataAccessLayer
{
    public class UserDAO
    {
        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            try
            {
                using (var context = new YouAreHeardContext())
                {
                    users = context.Users.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return users;
        }

        public static User GetUserById(int id)
        {
            User user = null;

            try
            {
                using (var context = new YouAreHeardContext())
                {
                    foreach (var u in context.Users)
                    {
                        if (u.UserId == id)
                        {
                            user = u;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return user;
        }

        public static User GetUserByEmail(string email)
        {
            User user = null;

            try
            {
                using (var context = new YouAreHeardContext())
                {
                    foreach (var u in context.Users)
                    {
                        if (u.Email == email)
                        {
                            user = u;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return user;
        }

        public static int AddUser(User user)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();

                    return user.UserId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void UpdateUser(User user)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var existingUser = context.Users.Find(user.UserId);

                    if (existingUser != null)
                    {
                        existingUser.Email = user.Email;
                        existingUser.Password = user.Password;
                        existingUser.Name = user.Name;
                        existingUser.Dob = user.Dob;
                        existingUser.RoleId = user.RoleId;
                        existingUser.FacebookPsid = user.FacebookPsid;
                        existingUser.IsActive = user.IsActive;
                        existingUser.Phone = user.Phone;

                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteUser(int id)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    var user = context.Users.Find(id);

                    if (user != null)
                    {
                        context.Users.Remove(user);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<int> AddUserAsync(User user)
        {
            try
            {
                using (var context = new YouAreHeardContext())
                {
                    await context.Users.AddAsync(user);
                    await context.SaveChangesAsync();

                    return user.UserId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding user asynchronously: " + ex.Message);
            }
        }

        public static int AddUserWithContext(User user, DataAccessLayer.YouAreHeardContext context)
        {
            try
            {
                context.Users.Add(user);
                context.SaveChanges();

                return user.UserId;
            }
            catch (Exception ex)
            {
                throw new Exception("Error adding user with transaction context: " + ex.Message);
            }
        }
    }
}
