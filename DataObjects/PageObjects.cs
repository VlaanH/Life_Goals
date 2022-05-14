using System;
using System.Collections.Generic;
using LifeGoals.Models;

namespace LifeGoals.PageObjects
{
   
    public class BasicView
    {
        public string UserAddress { get; set; }
        
        public string PageVisitor { get; set; }
    }

    public enum EPageStatus
    {
        Owner,
        Authorized,
        NotAuthorized,
        NotFound,
        NoAccount
        
    }
    public class AllGoalsScroll 
    {
        public EPageStatus PageStatus { get; set; }
        public string Address { get; set; }

        public int ScrollNumber { get; set; }
    }


    public class UserListDialog
    {
        public List<AppUser> Users { get; set; }
        
        public bool IsOpen { get; set; }

    }
    
    
    public class UniversalAddressPage:BasicView
    {
        public EPageStatus PageStatus { get; set; }
        public string Page { get; set; }
    }

    public class GoalAndStatusObjects
    {
        public EPageStatus PageStatus { get; set; }

        public GoalObjects GoalObjects { get; set; }
    }

    public class ListGoals
    {
        public AllGoalsScroll Scroll { get; set; }

        public List<GoalObjects> GoalObjectsList { get; set; }
    }
}