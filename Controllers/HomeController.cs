using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LifeGoals.Dbmanagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LifeGoals.Models;
using LifeGoals.PageObjects;
using Microsoft.AspNetCore.Hosting;
using lifeGoals.Cryptocurrencies.Ethereum;

namespace LifeGoals.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Privacy()
        {
            return View();
        }
        
        
        public IActionResult Profile(string address=default)
        {
            address = AddressManagement.AddressNormalization(address);


            if (UserManagement.IsUserExists(address) == true)
            {
                ViewData["address"] = address.ToLower();
                ViewData["status"] = "exist";
            }
            else if (address == null)
            {
                ViewData["status"] = "non";
                ViewData["address"] = "non";
            }
            else if(address=="null")
            {
                ViewData["status"] = "NoWeb3";
                ViewData["address"] = "non";
            }
            else
            {
                ViewData["address"] = address.ToLower();
                ViewData["status"]= "NotFound"; 
            }



            return View();
       }
        public IActionResult Feed(string address = default)
        {
            address = AddressManagement.AddressNormalization(address);


            if (UserManagement.IsUserExists(address) == true)
            {
                ViewData["address"] = address.ToLower();
                ViewData["status"] = "exist";
            }
            else if (address == null)
            {
                ViewData["status"] = "non";
                ViewData["address"] = "non";
            }
            else if(address=="null")
            {
                ViewData["status"] = "NoWeb3";
                ViewData["address"] = "non";
            }
            else
            {
                ViewData["address"] = address.ToLower();
                ViewData["status"]= "NotFound"; 
            }

            


            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult Error404()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}