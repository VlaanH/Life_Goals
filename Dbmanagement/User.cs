using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Humanizer;
using LifeGoals.Daemons;
using lifeGoals.DataObjects;
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

        public static List<AppUser> GetSubscribers(string address)
        {
            List<AppUser> subscribers = new List<AppUser>();
            
            using (ApplicationDbContext db= new ApplicationDbContext())
            {
                var subObj = db.Subscriptions.Where(u => u.User == address & u.Status==true).ToList();

                foreach (var subscriber in subObj)
                {
                    subscribers.Add(db.Users.Single(u => u.Address == subscriber.Subscriber)); 
                }
            }

            return subscribers;
        }
        public static List<AppUser> GetSubscriptions(string address)
        {
            List<AppUser> Subscriptions = new List<AppUser>();
            
            using (ApplicationDbContext db= new ApplicationDbContext())
            {
                var subObj = db.Subscriptions.Where(u => u.Subscriber == address & u.Status==true).ToList();

                foreach (var subscriber in subObj)
                {
                    Subscriptions.Add(db.Users.Single(u => u.Address == subscriber.User)); 
                }
            }

            return Subscriptions;
        }
        
        public static int GetSubscribersCount(string address)
        {
            int subscribersCount = 0;
            using (ApplicationDbContext db= new ApplicationDbContext())
            {
                subscribersCount = db.Subscriptions.Where(u => u.User == address & u.Status==true).ToList().Count;
            }

            return subscribersCount;
        }
        public static int GetSubscriptionsCount(string address)
        {
            int subscriptionsCount = 0;
            using (ApplicationDbContext db= new ApplicationDbContext())
            {
                subscriptionsCount = db.Subscriptions.Where(u => u.Subscriber == address & u.Status==true).ToList().Count;
                
                
            }

            return subscriptionsCount;
        }

        public static bool IsSubscriber(string address,string subscriberAddress)
        {
            bool isSubscriber = false;
            using (ApplicationDbContext db= new ApplicationDbContext())
            {
                var singleOrDefault = db.Subscriptions.SingleOrDefault(u => u.User == address & u.Subscriber==subscriberAddress & u.Status==true);
                
                if (singleOrDefault!=default)
                {
                    isSubscriber = true;
                }
                
            }

            return isSubscriber;
        }

        public static int GetGoalsCount(string address)
        {
            int goalsCount = 0;
            using (ApplicationDbContext db= new ApplicationDbContext())
            {
                goalsCount = db.Goals.Where(u => u.User == address).ToList().Count;
            }

            return goalsCount;
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