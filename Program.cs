using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LifeGoals.Daemons;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace LifeGoals
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DaemonsInit();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });


        private static void DaemonsInit()
        {
            new Thread(()  =>
            {
               
                Zcash.UpdateCurrencyValue(); 
                
            }).Start();
            new Thread(()  =>
            {
                UserVerification.UpdateVerificationDb();
                
            }).Start();
          

        }

    }
}