using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using LifeGoals.Daemons;
using LifeGoals.Models;

namespace LifeGoals.Dbmanagement
{
   public static class UserManagement
   {
       public static string StandardUserImage = "/UserImages/standardUser.png";
       public static string StandardUserBackground = "/UserBackground/standardBackground.png";
        public static AppUser GetUser(string address)
        {
            AppUser user = default;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                user = db.Users.Single(u => u.Address == address);
            }

            return user;
    
        }


       
        public static bool IsUserExists(string address)
        {
            bool result = true;
            try
            {
                AppUser user = default;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    user = db.Users.Single(u => u.Address == address);
                }
            }
            catch (Exception e)
            {
                result = false;
            }
           

            return result;
    
        }





   }


}