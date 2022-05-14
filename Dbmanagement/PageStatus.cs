using System;
using LifeGoals.PageObjects;

namespace LifeGoals.Dbmanagement
{
    public static class PageStatus
    {
        public static EPageStatus GetPageStatus(this BasicView basicView)
        {

            if (UserManagement.IsUserExists(basicView.UserAddress))
            {

                if (UserManagement.IsUserExists(basicView.PageVisitor))
                {
                    if (basicView.PageVisitor==basicView.UserAddress)
                    {
                        return EPageStatus.Owner;
                    }
                    else
                    {
                        return EPageStatus.Authorized;
                    }
                }
                else
                {
                    return EPageStatus.NotAuthorized;
                }
                
            }
            else
            {
                if (basicView.PageVisitor==basicView.UserAddress)
                {
                    return EPageStatus.NoAccount;
                }
                else
                {
                    return EPageStatus.NotFound;
                }
                
            }
         
            
        }

    }
}