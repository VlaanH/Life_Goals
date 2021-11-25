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

        public static void DoImportant(int goalId,bool important)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Goals.Single(id => id.Id == goalId).Important = important;
                db.SaveChanges();
            }
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

        public static void ChangeGoalStatus(EGoalStageImplementation status,int goalId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Goals.Single(id => id.Id == goalId).StageImplementation = status;
                db.SaveChanges();
            }
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