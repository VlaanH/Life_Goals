using System;
using System.Collections.Generic;
using LifeGoals.Models;

namespace LifeGoals.PageObjects
{
    public class AllGoalsScroll 
    {
        public string Address { get; set; }

        public int ScrollNumber { get; set; }
    }

    public class BasicView
    {
        public string UserAddress { get; set; }
        
        public string PageVisitor { get; set; }
    }
    
    
    
    public class UserListDialog
    {
        public List<AppUser> Users { get; set; }
        
        public bool IsOpen { get; set; }

    }
    
    
    public class UniversalAddressPage:BasicView
    { 
        public string Page { get; set; }
    }
    
    public class ListGoals
    {
        public AllGoalsScroll Scroll { get; set; }

        public List<GoalObjects> GoalObjectsList { get; set; }
    }
}