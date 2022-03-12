using System;
using System.Collections.Generic;
using System.IO;
using LifeGoals.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LifeGoals.Cryptocurrencies;
using LifeGoals.Dbmanagement;
using System.Text.Json;
using lifeGoals.DataObjects;

namespace LifeGoals.Daemons
{
    public static class SynchronizationSmartContract
    {
        public static void StartSync()
        {
            while (true)
            {
               
                SyncUserAddress();
                SyncSubscriptions();
                SyncGoals();
                Thread.Sleep(2000);

                
            }
        }

        private static string JsonNormalization(this string json)
        {
            
            //replacing all html tags
            json=json.Replace("<","'");
            json=json.Replace(">","'");
            
            
            //replacing special characters with an indent tag
            json=json.Replace("\n","<br>");
            json=json.Replace("\r","<br>");
            
            
            json=json.Replace(@"\",@"\\");
            return json;
        }
        static async void SyncSubscriptions()
        {
            var jsonAllUser = await new SmartContractRequest().
                GetStringFunction(appSettings.ContractAddressVerification,appSettings.ContractAbiVerification, "allUserSubscriptions");
                
            string [] split = jsonAllUser.Split("\n\r");
               
            var onlyNewSyncData = ReadSubscription(split.Distinct().ToList());
               
            SynchronizationSmartContractsDb.SynchronizationSubscription(onlyNewSyncData);
            
        }

        static async void SyncUserAddress()
        {
            var jsonAllUser= await new SmartContractRequest().
                GetStringFunction(appSettings.ContractAddressVerification,appSettings.ContractAbiVerification, "allUsers");
                
            string [] split = jsonAllUser.Split("\n\r");
               
            var onlyNewSyncData = ReadUser(split.Distinct().ToList());
               
            SynchronizationSmartContractsDb.SynchronizationUsers(onlyNewSyncData);
            
        }
        static async void SyncGoals()
        {
            var jsonAllGoal= await new SmartContractRequest().
                GetStringFunction(appSettings.ContractAddressVerification,appSettings.ContractAbiVerification, "allGoals");

        
            string [] split = jsonAllGoal.Split("\n\r");

            var onlyNewSyncData = ReadGoals(split.Distinct().ToList());
       
           
            SynchronizationSmartContractsDb.SynchronizationGoals(onlyNewSyncData);
            
        }


        private static List<GoalObjects> ReadGoals(List<string> jsonData)
        {
            List<GoalObjects> data = new List<GoalObjects>();
            for (int i = 0; i < jsonData.Count; i++)
            {
                try
                {
                    
                    var goal = JsonSerializer.Deserialize<GoalObjects>(jsonData[i].JsonNormalization());
                    
                   
                    if (goal != null)
                        data.Add(goal);
                    
                    
                }
                catch (Exception e)
                {
                   
                    // ignored
                } 
            }
                
            
            
            return data;
        }
        
        private static List<AppUser> ReadUser(List<string> jsonData)
        {
            List<AppUser> data = new List<AppUser>();
            for (int i = 0; i < jsonData.Count; i++)
            {
                try
                {
                    var user = JsonSerializer.Deserialize<AppUser>(jsonData[i].JsonNormalization());
                    
                    if (user != null) 
                        data.Add(user);
                }
                catch (Exception e)
                {
                    // ignored
                } 
            }
                
            
            
            return data;
        }
        private static List<SubscriptionObjects> ReadSubscription(List<string> jsonData)
        {
            List<SubscriptionObjects> data = new List<SubscriptionObjects>();
            for (int i = 0; i < jsonData.Count; i++)
            {
                try
                {
                    var suber = JsonSerializer.Deserialize<SubscriptionObjects>(jsonData[i].JsonNormalization());
                    
                    if (suber != null) 
                        data.Add(suber);
                }
                catch (Exception e)
                {
                  
                    // ignored
                } 
            }
                
            
            
            return data;
        }

    }
}