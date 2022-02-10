using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using LifeGoals.Cryptocurrencies;
using LifeGoals.Daemons;
using LifeGoals.Models;

namespace LifeGoals.Dbmanagement
{
    public static class Goals
    {
        public static List<GoalObjects> GetUsersFeed(string userAddress)
        {
            List<GoalObjects> feedList = new List<GoalObjects>();
            
            var userSubscriptions= UserManagement.GetSubscriptions(userAddress);

            foreach (var user in userSubscriptions)
                feedList.AddRange(GetUserGoals(user.Address));

            

            return feedList;
        }
        

        public static List<GoalObjects> GetAllImportantGoals(string userAddress)
        {
            List<GoalObjects> userImportantGoalObjectsList;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                userImportantGoalObjectsList = db.Goals.Where(g => g.User == userAddress&g.Important==true).ToList();
            }
            userImportantGoalObjectsList.Reverse();
            return userImportantGoalObjectsList;
        }


        public static GoalObjects GetGoal(int userAddress)
        {
            GoalObjects userGoalObjects;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                
                userGoalObjects = db.Goals.Single(g => g.Id == userAddress);
                
            }


            return userGoalObjects;
        }



        
        public static List<GoalObjects> GetUserGoals(string userAddress)
        {
            List<GoalObjects> userGoalObjectsList;
            
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                
                userGoalObjectsList = db.Goals.Where(g => g.User == userAddress).ToList();

            }
            userGoalObjectsList.Reverse();
            
            
            return userGoalObjectsList;
        }
   
    }
}