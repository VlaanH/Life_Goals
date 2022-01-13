using System;
using System.Collections.Generic;
using System.Linq;
using LifeGoals.Models;

namespace LifeGoals.Dbmanagement
{
    public static class SynchronizationSmartContractsDb
    {
        public static void SynchronizationUsers(List<AppUser> userList)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                foreach (var contractUser in userList)
                {
                    
                    if (db.Users.SingleOrDefault(dbUser => dbUser.Id == contractUser.Id) == default)
                    {
                        Console.WriteLine("User add");
                        db.Users.Add(contractUser);
                    }
                    else
                    {
                       
                        var dbUsers = db.Users.SingleOrDefault(dbUsers => dbUsers.Id == contractUser.Id);
                        if (dbUsers.Background!=contractUser.Background)
                        {
                            Console.WriteLine("User update");
                            dbUsers.Background = contractUser.Background;
                        }
                        else if (dbUsers.Imag!=contractUser.Imag)
                        {
                            Console.WriteLine("User update");
                            dbUsers.Imag = contractUser.Imag;
                        }
                        else if (dbUsers.Description!=contractUser.Description)
                        {
                            Console.WriteLine("User update");
                            dbUsers.Description = contractUser.Description;
                        }
                    }
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    // ignored
                }
            }
            
        }
        public static void SynchronizationGoals(List<GoalObjects> goalObjectsList)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               

                foreach (var contractGoal in goalObjectsList)
                {
                    //goal not exist
                    if (db.Goals.SingleOrDefault(dbGoal => dbGoal.Id == contractGoal.Id) == default)
                    {
                        Console.WriteLine("Add goal");
                        
                        db.Goals.Add(contractGoal);
                      
                    }
                    else
                    {
                       
                        var dbGoal = db.Goals.SingleOrDefault(dbGoal => dbGoal.Id == contractGoal.Id);
                        if (dbGoal.StageImplementation!=contractGoal.StageImplementation)
                        {
                            Console.WriteLine("Goal update");
                            dbGoal.StageImplementation = contractGoal.StageImplementation;
                        }
                        else if (dbGoal.Important!=contractGoal.Important)
                        {
                            Console.WriteLine("Goal update");
                            dbGoal.Important = contractGoal.Important;
                        }
                        
                    }
                    
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    // ignored
                }
            }
            
        }
    }
}