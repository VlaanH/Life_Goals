using System;
using System.Diagnostics;
using LifeGoals.Dbmanagement;
using Microsoft.AspNetCore.Mvc;
using LifeGoals.Models;
using LifeGoals.PageObjects;
using lifeGoals.Cryptocurrencies.Ethereum;

namespace LifeGoals.Controllers
{
    public class HomeController : Controller
    {
        String GetMethodName()
        {
            //GetFrame(1) hierarchy number
            return new StackTrace(false).GetFrame(1).GetMethod().Name;
        }

        public IActionResult Privacy()
        {
            return View("Pages/Privacy");
        }

        public IActionResult Profile(string address=default)
        {
            return View("HomePages/UniversalAddressPage",new UniversalAddressPage{UserAddress = address,Page = GetMethodName()});
        }
        public IActionResult Feed(string address = default)
        { 
            return View("HomePages/UniversalAddressPage",new UniversalAddressPage{UserAddress = address,Page = GetMethodName()});
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