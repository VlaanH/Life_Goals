
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace LifeGoals.Cryptocurrencies
{


    public class CurrenciesKeyObject
    {
       
        public string PrivateKey { get; set; }

     
        public string PublicAddress{ get; set; }

    }
}