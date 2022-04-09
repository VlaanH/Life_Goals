using System.Diagnostics;
using LifeGoals.Dbmanagement;
using Microsoft.AspNetCore.Mvc;
using LifeGoals.Models;
using lifeGoals.Cryptocurrencies.Ethereum;

namespace LifeGoals.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Privacy()
        {
            return View("Pages/Privacy");
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



            return View("Pages/Profile");
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

            


            return View("Pages/Feed");
        }

        public IActionResult Settings()
        {
            return View("Pages/Settings");
        }

        public IActionResult Error404()
        {
            return View("Pages/Error404");
        }
        public IActionResult Register()
        {
            return View("Pages/Register");
        }
        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}