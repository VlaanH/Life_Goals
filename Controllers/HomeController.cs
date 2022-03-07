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


        IWebHostEnvironment _appEnvironment ;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IWebHostEnvironment appEnvironment)
        { 
            _appEnvironment = appEnvironment;
      
            _logger = logger;
        }

        public IActionResult GetSubscriptionStatus(string address,string pageVisitor)
        {
            address = AddressManagement.AddressNormalization(address);
            pageVisitor=AddressManagement.AddressNormalization(pageVisitor);
         
            
            
            return PartialView("Profile/UserAllData",new UserAllData()
                {UserAddress = address, PageVisitor = pageVisitor});
        }
        

        public IActionResult GetSubscribers(string address)
        {
            address = AddressManagement.AddressNormalization(address);
            var allUserSubscribers = UserManagement.GetSubscribers(address);
            
            return PartialView("Profile/UserListDialog",new UserListDialog(){Users = allUserSubscribers,IsOpen = true});
        }
        public IActionResult GetSubscriptions(string address)
        {
            address = AddressManagement.AddressNormalization(address);
            var allUserSubscriptions = UserManagement.GetSubscriptions(address);
            
            return PartialView("Profile/UserListDialog",new UserListDialog(){Users = allUserSubscriptions,IsOpen = true});
        }
        
        public IActionResult GoalLineUpdate(string userId)
        {
            return PartialView("Profile/GoalLine",userId);
        }
       
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
            else
            {
                ViewData["address"] = address.ToLower();
                ViewData["status"]= "NotFound"; 
            }

            


            return View();
        }

        public async Task<ActionResult> UpdateGoals(string address,int scrollNumber)
        {
            address = AddressManagement.AddressNormalization(address);
            
            return PartialView("Goal/GetAllGoals",new AllGoalsScroll(){Address =  address, ScrollNumber = scrollNumber});
        }
        public async Task<ActionResult> UpdateFeedGoals(string address,int scrollNumber)
        {
           
            return PartialView("Goal/GetUserFeed",new AllGoalsScroll(){Address =  address, ScrollNumber = scrollNumber});
        }
        
        public async Task<ActionResult> Goal(int goalId)
        {
            var goal = Goals.GetGoal(goalId);
           
            return PartialView("Goal/Goal",goal);
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