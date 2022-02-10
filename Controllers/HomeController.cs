using System;
using System.Diagnostics;
using System.Threading.Tasks;
using LifeGoals.Dbmanagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LifeGoals.Models;
using LifeGoals.PageObjects;
using Microsoft.AspNetCore.Hosting;

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
            
            if (address != null)
            {
                address = address.ToLower();
                if (address.Length==42)
                {
                    address=address.Remove(0,2);
                }
            }
            if (pageVisitor != null)
            {
                pageVisitor = pageVisitor.ToLower();
                if (pageVisitor.Length==42)
                {
                    pageVisitor=pageVisitor.Remove(0,2);
                }
            }
            
            
            return PartialView("Profile/UserAllData",new UserAllData()
                {UserAddress = address, PageVisitor = pageVisitor});
        }
        

        public IActionResult GetSubscribers(string address)
        {
            var allUserSubscribers = UserManagement.GetSubscribers(address);
            
            return PartialView("Profile/UserListDialog",new UserListDialog(){Users = allUserSubscribers,IsOpen = true});
        }
        public IActionResult GetSubscriptions(string address)
        {
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
            if (address != null)
            {
                address = address.ToLower();
                if (address.Length==42)
                {
                    address=address.Remove(0,2);
                }
            }



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
        public IActionResult Feed(string address = default)
        {
            if (address != null)
            {
                address = address.ToLower();
                if (address.Length==42)
                {
                    address=address.Remove(0,2);
                }
            }



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