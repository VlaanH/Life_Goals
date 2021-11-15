using System;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LifeGoals.Daemons
{
    
    public class Zcash
    {
        private static string GetZcashValueForKraken(string quantity = default,string currency1 = default,string currency2 = default)
        {
            string APIresponse = default;
            double multiplyValue = default;
            string parsData = default;
            string roundedMultipleValues = default; 
          
            WebClient wc = new WebClient();

            APIresponse = wc.DownloadString($"https://api.kraken.com/0/public/Ticker?pair="+currency1+currency2);
            try
            {
                string ParsPatern = @":{""a"":\[""([\w \W ]+)\],""b"":\[";
                parsData = Regex.Match(APIresponse, ParsPatern).Groups[1].Value;
                for (int i = 0; i < 2; i++)
                    parsData = Regex.Match(parsData, @"([\w \W ]+)"",""").Groups[1].Value;

                //remove spaces in line
                string withoutSpaces = parsData.Replace(" ", "");
              
                multiplyValue = double.Parse(withoutSpaces, new CultureInfo("en-us")) *
                                double.Parse(quantity, new CultureInfo("en-us"));
            }
            catch (Exception e)
            {
                parsData = "Error";                
            }


            
            if (parsData=="Error") 
            {   //An attempt to change a currency pair
                APIresponse = wc.DownloadString($"https://api.kraken.com/0/public/Ticker?pair="+currency2+currency1);
                try
                {
                    string ParsPatern = @":{""a"":\[""([\w \W ]+)\],""b"":\[";
                    parsData = Regex.Match(APIresponse, ParsPatern).Groups[1].Value;
                    for (int i = 0; i < 2; i++)
                        parsData = Regex.Match(parsData, @"([\w \W ]+)"",""").Groups[1].Value;
                    
                    //remove spaces in line
                    string withoutSpaces = parsData.Replace(" ", "");

                  
                    multiplyValue = double.Parse(quantity, new CultureInfo("en-us")) /
                                        double.Parse(withoutSpaces, new CultureInfo("en-us"));
                    
                }
                catch (Exception e)
                {
                    if (multiplyValue == 0)
                        return "Error";      
                }

            }
              
            //rounding to 8 decimal places
            roundedMultipleValues = Math.Round(multiplyValue, 9).ToString("0.##########");
           
            
            return roundedMultipleValues;
        }

        public static string AddZero(string value)
        {

            for ( ;value.Length <10;)
            {
                value += "0";
            }

            return value;
        }







        public static async void UpdateCurrencyValue() 
        {
            while (true)
            {
                int mult = 600;
               
                DaemonsData.CurrencyValue = GetZcashValueForKraken("1","ZEC","USD");
                Console.WriteLine(DaemonsData.CurrencyValue);
                await Task.Delay(1000*mult);
         

            }
        }


    }
}