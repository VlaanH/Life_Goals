using System.Threading.Tasks;
using lifeGoals.Cryptocurrencies.Ethereum;
using LifeGoals.Dbmanagement;
using LifeGoals.PageObjects;
using Microsoft.AspNetCore.Mvc;

namespace LifeGoals.Controllers
{
    public class AjaxDataUpdateController:Controller
    {
        public IActionResult GetSubscriptionStatus(string address,string pageVisitor)
        {
            address = AddressManagement.AddressNormalization(address);
            pageVisitor=AddressManagement.AddressNormalization(pageVisitor);
         
            
            
            return PartialView("Profile/UserAllData",new BasicView()
                {UserAddress = address, PageVisitor = pageVisitor});
        }

        public IActionResult GetSubscribers(string address)
        {
            address = AddressManagement.AddressNormalization(address);
            var allUserSubscribers = UserManagement.GetSubscribers(address);
            
            return PartialView("Profile/UserListDialog",new UserListDialog(){Users = allUserSubscribers,IsOpen = true});
        }
        
        public IActionResult GoalLineUpdate(string userId)
        {
            return PartialView("Profile/GoalLine",userId);
        }
        
        public IActionResult GetSubscriptions(string address)
        {
            address = AddressManagement.AddressNormalization(address);
            var allUserSubscriptions = UserManagement.GetSubscriptions(address);
            
            return PartialView("Profile/UserListDialog",new UserListDialog(){Users = allUserSubscriptions,IsOpen = true});
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

    }
}