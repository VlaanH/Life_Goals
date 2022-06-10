using System;
using lifeGoals.Cryptocurrencies.Ethereum;
using LifeGoals.Dbmanagement;
using LifeGoals.PageObjects;
using Microsoft.AspNetCore.Mvc;

namespace LifeGoals.Controllers
{
    public class AjaxPageTransitionController:Controller
    {
        public IActionResult Privacy()
        {
            return PartialView("Pages/Privacy");
        }


        public IActionResult Profile(string addressVisitor,string address = default)
        {
            if (address!=default)
                address = AddressManagement.AddressNormalization(address);

            if (addressVisitor!=default)
                addressVisitor = AddressManagement.AddressNormalization(addressVisitor);
            
            var pageStatus = new BasicView { PageVisitor = addressVisitor, UserAddress = address }.GetPageStatus();
            

            if (pageStatus == EPageStatus.NotFound)
            {
                return PartialView("Pages/Error404");
            }
            else if (pageStatus == EPageStatus.NoAccount)
            {
                return PartialView("Pages/Register");
            }
            else
            {
                return PartialView("Pages/Profile", new UniversalAddressPage { UserAddress = address, PageVisitor = addressVisitor, PageStatus = pageStatus });
            }
        }
        public IActionResult Feed(string addressVisitor,string address = default)
        {
            if (address!=default)
                address = AddressManagement.AddressNormalization(address);

            if (addressVisitor!=default)
                addressVisitor = AddressManagement.AddressNormalization(addressVisitor);
            
            var pageStatus = new BasicView { PageVisitor = addressVisitor, UserAddress = address }.GetPageStatus();


            if (pageStatus == EPageStatus.NotFound)
            {
                return PartialView("Pages/Error404");
                
            }
            else if (pageStatus == EPageStatus.NoAccount)
            {
                return PartialView("Pages/Register");
            }
            else
            {
                return PartialView("Pages/Feed", new UniversalAddressPage { UserAddress = address, PageVisitor = addressVisitor, PageStatus = pageStatus });
            }
           
        }

        public IActionResult Goal(string addressVisitor,string address = default)
        {
      
            if (addressVisitor!=default)
                addressVisitor = AddressManagement.AddressNormalization(addressVisitor);

            try
            {
                var goalObj = Goals.GetGoal(int.Parse(address));
                
                var pageStatus = new BasicView { PageVisitor = addressVisitor, UserAddress = goalObj.User }.GetPageStatus();
                
                return PartialView("Pages/goal", new GoalAndStatusObjects{PageStatus = pageStatus,GoalObjects = goalObj});

            }
            catch (Exception)
            {
                return PartialView("Pages/Error404");
            }

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