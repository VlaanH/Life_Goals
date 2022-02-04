using System;
using System.Collections.Generic;
using System.Linq;
using lifeGoals.DataObjects;
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
                        
                        if (contractUser.Background == "non")
                            contractUser.Background = UserManagement.StandardUserBackground;
                        if (contractUser.Imag == "non")
                            contractUser.Imag = UserManagement.StandardUserImage;
                        
                        db.Users.Add(contractUser);
                    }
                    else
                    {
                       
                        var dbUsers = db.Users.SingleOrDefault(dbUsers => dbUsers.Id == contractUser.Id);
                        
                        if (contractUser.Background == "non")
                            contractUser.Background = UserManagement.StandardUserBackground;
                        if (contractUser.Imag == "non")
                            contractUser.Imag = UserManagement.StandardUserImage;
                        
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
        public static void SynchronizationSubscription(List<SubscriptionObjects> subscriptionObjectsList)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
               

                foreach (var contractSubscription in subscriptionObjectsList)
                {
                    //goal not exist
                    if (db.Subscriptions.SingleOrDefault(dbSubscription => dbSubscription.Id == contractSubscription.Id) == default)
                    {
                        Console.WriteLine("Add Subscription");
                        
                        db.Subscriptions.Add(contractSubscription);
                      
                    }
                    else
                    {
                       
                        var dbGoal = db.Subscriptions.SingleOrDefault(dbSubscription => dbSubscription.Id == contractSubscription.Id);
                        
                        if (dbGoal.Status!=contractSubscription.Status)
                        {
                            Console.WriteLine("Subscription update");
                            dbGoal.Status = contractSubscription.Status;
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