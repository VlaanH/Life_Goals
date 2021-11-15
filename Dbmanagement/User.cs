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
        public static ApplicationUser GetUser(string userId)
        {
            ApplicationUser user = default;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                user = db.Users.Single(u => u.Id == userId);
            }

            return user;
    
        }
       
        public static void ReplacementImageUser(string userId,string necessaryImage,string rootPath)
        {
            string oldUserImagePath = GetUser(userId).Imag;

            SetUserImage(userId,necessaryImage);
            
            if (oldUserImagePath!=StandardUserImage & File.Exists(rootPath+oldUserImagePath))
                File.Delete(rootPath+oldUserImagePath);



        }
        
        
        public static bool IsUserExists(string userId)
        {
            bool result = true;
            try
            {
                ApplicationUser user = default;
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    user = db.Users.Single(u => u.Id == userId);
                }
            }
            catch (Exception e)
            {
                result = false;
            }
           

            return result;
    
        }


        private static void SetUserImage(string userId,string imagePath)
        {
            using (ApplicationDbContext db =new  ApplicationDbContext())
            {
               db.Users.Single(id => id.Id == userId).Imag=imagePath;
               db.SaveChangesAsync();
            }   
            
        }


    }


}