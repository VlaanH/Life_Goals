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

namespace LifeGoals.Daemons
{
    public static class SynchronizationSmartContract
    {
        public static void StartSync()
        {
            while (true)
            {
               
                SyncUserAddress();
                SyncGoals();
                Thread.Sleep(2000);

                
            }
        }

        private static string JsonNormalization(string json)
        {
        
            
            json=json.Replace("\n","<br>");
            json=json.Replace("\r","<br>");
            json=json.Replace("/","//");
            json=json.Replace(@"\",@"\\");


            return json;
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

                    jsonData[i] = JsonNormalization(jsonData[i]);
                    

                    var goal = JsonSerializer.Deserialize<GoalObjects>(jsonData[i]);


                   
                    if (goal != null)
                    {
                        data.Add(goal);
                    }

                    
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
                    jsonData[i] = JsonNormalization(jsonData[i]);
                    
                    var user = JsonSerializer.Deserialize<AppUser>(jsonData[i]);
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
        

    }
}