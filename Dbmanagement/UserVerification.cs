using System;
using System.Collections.Generic;
using System.Linq;
using LifeGoals.Models;

namespace LifeGoals.Dbmanagement
{
    public class UserVerificationDb
    {
        public static void SynchronizationVerification(List<VerificationUserData> verificationUserList)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var userId = db.VerificationUsers.ToList();

                foreach (var id in verificationUserList)
                {
                    
                    if (db.VerificationUsers.SingleOrDefault(dbid => dbid.VerificationUser == id.VerificationUser) == default)
                    {
                        Console.WriteLine("Verification update");
                        db.VerificationUsers.Add(id);
                    }
                    
                }

              
                db.SaveChanges();
            }
            
        }

    }
}