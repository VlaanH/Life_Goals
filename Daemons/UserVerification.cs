using System;
using System.Collections.Generic;
using System.IO;
using LifeGoals.Models;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using LifeGoals.Cryptocurrencies;
using LifeGoals.Dbmanagement;

namespace LifeGoals.Daemons
{
    public static class UserVerification
    {
        public static async void UpdateVerificationDb()
        {
            while (true)
            {
                
                var jsonAllUser= await new SmartContractRequest().
                    GetStringFunction(appSettings.ContractAddressVerification,appSettings.ContractAbiVerification, "allVerificationUser");
                string [] split = jsonAllUser.Split("\n\r");
               
                var onlyId = Read(split.Distinct().ToList());
               
                UserVerificationDb.SynchronizationVerification(onlyId);
               
                Thread.Sleep(60000);
            }
        }

        
        private static List<VerificationUserData> Read(List<string> jsonData)
        {
            List<VerificationUserData> data = new List<VerificationUserData>();
            for (int i = 0; i < jsonData.Count; i++)
            {
                try
                {
                    
                    var stringData = JsonSerializer.Deserialize<LifeGoals.Models.VerificationUserData>(jsonData[i]);
                    if (stringData != null) 
                        data.Add(new VerificationUserData{VerificationUser = stringData.VerificationUser,
                                                            VerificationAddress = stringData.VerificationAddress});
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