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
        
        public static List<GoalObjects> GetAllImportantGoals(string userId)
        {
            List<GoalObjects> userImportantGoalObjectsList;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                userImportantGoalObjectsList = db.Goals.Where(g => g.User == userId&g.Important==true).ToList();
                

            }
            userImportantGoalObjectsList.Reverse();
            return userImportantGoalObjectsList;
        }


        public static GoalObjects GetGoal(int goalId)
        {
            GoalObjects userGoalObjects;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                userGoalObjects = db.Goals.Single(g => g.Id == goalId);
                
            }


            return userGoalObjects;
        }



        
        public static List<GoalObjects> GetUserGoals(string userId)
        {
            List<GoalObjects> userGoalObjectsList;
            
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
           
                userGoalObjectsList = db.Goals.Where(g => g.User == userId).ToList();
                
                
                

            }
            userGoalObjectsList.Reverse();
            
            
            return userGoalObjectsList;
        }
   
    }
}