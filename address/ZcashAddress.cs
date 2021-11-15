using System;
using System.Text.RegularExpressions;
using System.Threading.Channels;

namespace LifeGoals.address
{
    public class ZcashAddress
    {
        public static bool Pars(string address)
        {
            string adParss = Regex.Match(address, @"t1([\w \W ]+)").Groups[1].Value;


            if (adParss == "" )
            {
                return false;
                
            }
            else if(adParss.Length == 33)
            {
                return true; 
            }
            else
            {
                return false;
            }
       
            
        }


    }
}