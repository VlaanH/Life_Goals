using lifeGoals.Cryptocurrencies.Ethereum;
using LifeGoals.Dbmanagement;
using Microsoft.AspNetCore.Mvc;

namespace LifeGoals.Controllers
{
    public class AjaxPageTransitionController:Controller
    {
        public IActionResult Privacy()
        {
            return PartialView("Pages/Privacy");
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
                ViewData["status"] = "NotFound"; 
            }



            return PartialView("Pages/Profile");
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
                ViewData["status"] = "NotFound"; 
            }

            


            return PartialView("Pages/Feed");
        }

        public IActionResult Settings()
        {
            return PartialView("Pages/Settings");
        }

        public IActionResult Error404()
        {
            return PartialView("Pages/Error404");
        }
        public IActionResult Register()
        {
            return PartialView("Pages/Register");
        }
    }
}