using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using LifeGoals.Daemons;
using LifeGoals.Models;

namespace LifeGoals.Dbmanagement
{
    public static class Goals
    {

        public static void GoalAddDb(GoalObjects goal)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                 
                db.Goals.Add(goal);

                db.SaveChanges();
            }
           
        }
        
        public static List<GoalObjects> GetUserGoals(string user)
        {
            List<GoalObjects> userGoalObjectsList;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                userGoalObjectsList = db.Goals.Where(g => g.User == user).ToList();
                
                
                

            }
            userGoalObjectsList.Reverse();
            
            
            return userGoalObjectsList;
        }
   
    }
}