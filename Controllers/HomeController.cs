using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Threading.Tasks;
using LifeGoals.Daemons;
using LifeGoals.Dbmanagement;
using System.Drawing;
using System.Threading;
using LifeGoals.Cryptocurrencies;
using LifeGoals.Images;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LifeGoals.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

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
        
        [ValidateRecaptcha]
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> AddFUserImage(IFormFile uploadedFile)
        {
            if (uploadedFile != null )
                if (uploadedFile.Length<10000000)
                {
                    Console.WriteLine(uploadedFile.Length);
                    var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
               
                
                    string path = "/UserImages/" +userID + ImageManagement.GetRandomImageName()+".jpg";
                    string fullPath = _appEnvironment.WebRootPath + path;
               
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        await uploadedFile.CopyToAsync(fileStream);
                
                    
                
                
                
                
                    var imageFormat = ImageManagement.GetImageFormat(fullPath);
                
                    switch (imageFormat)
                    {
                        case ImageManagement.ImageFormat.jpeg:
                        {
                        
                            ImageManagement.ResizeImage(fullPath,new Size(512,512));
                            UserManagement.ReplacementImageUser(userID,path, _appEnvironment.WebRootPath);
                            break;
                        }
                        case ImageManagement.ImageFormat.png:
                        {
                            ImageManagement.ResizeImage(fullPath,new Size(512,512));
                            UserManagement.ReplacementImageUser(userID,path, _appEnvironment.WebRootPath);
                            break;
                        } 
                    }
                
               

               
                }
            
            return Redirect("/Identity/Account/Manage");
        }

        public IActionResult EditDescription(string description)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            UserManagement.SetUserDescription(userId,description);
            
            return Redirect("/Identity/Account/Manage");
        }

        public async Task<IActionResult> AddFUserBackground(IFormFile uploadedFile)
        {
            if (uploadedFile != null )
                if (uploadedFile.Length<10000000)
                {
                    Console.WriteLine(uploadedFile.Length);
                    var userID = User.FindFirstValue(ClaimTypes.NameIdentifier);
               
                
                    string path = "/UserBackground/" +userID + ImageManagement.GetRandomImageName()+"B"+".jpg";
                    string fullPath = _appEnvironment.WebRootPath + path;
               
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        await uploadedFile.CopyToAsync(fileStream);
                
                    
                
                
                
                
                    var imageFormat = ImageManagement.GetImageFormat(fullPath);
                
                    switch (imageFormat)
                    {
                        case ImageManagement.ImageFormat.jpeg:
                        {
                        
                            ImageManagement.ResizeImage(fullPath,new Size(1920,1080));
                            UserManagement.ReplacementBackgroundUser(userID,path, _appEnvironment.WebRootPath);
                            break;
                        }
                        case ImageManagement.ImageFormat.png:
                        {
                            ImageManagement.ResizeImage(fullPath,new Size(1920,1080));
                            UserManagement.ReplacementBackgroundUser(userID,path, _appEnvironment.WebRootPath);
                            break;
                        } 
                    }
                
               

               
                }
            
            return Redirect("/Identity/Account/Manage");
        }
        
        
        [Authorize] 
        public IActionResult GoalLineUpdate(string userId)
        {
            return PartialView("Profile/GoalLine",userId);
        }
       
        public IActionResult Privacy()
        {
            return View();
        }
        
        
        public IActionResult Profile(GoalObjects goal,string id=default)
       {
           var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
          
           
           if (id==default & User.Identity.IsAuthenticated==false)
               ViewData["id"] = "zero";
           else if(id==default)
               ViewData["id"] = userId;
           else if(UserManagement.IsUserExists(id)==true)
               ViewData["id"] = id;
           else
               ViewData["id"] = "non";
           

           return View();
       }
        
        [Authorize] 
        public async Task<ActionResult> GoalAdd(string body,string titles,bool isDonate,string donateValue,bool isMyAddress,string myAddress)
        {
            await Task.Run(() =>
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (isDonate == true & isMyAddress==false)
                {
                    var keys = new EthereumRinkebyNet().GenerateAddress();

                    double dDonateValue = 0;
                    try
                    {
                        dDonateValue = Convert.ToDouble(donateValue, new CultureInfo("en-us"));
                    }
                    catch (Exception e)
                    {
                        dDonateValue = 0;
                    }

                   

                    Goals.GoalAddDb(new GoalObjects()
                    {
                        Body = body, Titles = titles,
                        User = userId, IsDonate = true,
                        DonateValue = dDonateValue.ToString("0.########",new CultureInfo("en-us")),
                        PublicAddress = keys.PublicAddress,
                        PrivateKey = keys.PrivateKey,
                        MaxDonateValue = "0"
                    });
                }
                else if(isMyAddress==true)
                {
                    double dDonateValue = 0;
                    try
                    {
                        dDonateValue = Convert.ToDouble(donateValue, new CultureInfo("en-us"));
                    }
                    catch (Exception e)
                    {
                        dDonateValue = 0;
                    }

                   

                    Goals.GoalAddDb(new GoalObjects()
                    {
                        Body = body, Titles = titles,
                        User = userId, IsDonate = true,
                        DonateValue = dDonateValue.ToString("0.########",new CultureInfo("en-us")),
                        PublicAddress = myAddress,
                        IsPrivateDonateGoal = true,
                        PrivateKey = $"https://etherscan.io/address/{myAddress}",
                        MaxDonateValue = "0"
                    });
                }
                else
                {
                    Goals.GoalAddDb(new GoalObjects() {Body = body, Titles = titles, User = userId});
                }


                ViewData["id"] = userId;
            });
            
           
            
            return PartialView("Profile");
        }
    
        [Authorize] 
        public IActionResult DoImportant(bool status,int goalId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var goal = Goals.GetGoal(goalId);

            if (goal.User == userId)
            {
                Goals.DoImportant(goalId,status);
                goal.Important = status;
            }

            


            return PartialView("Profile/Goal",goal);
        }

        [Authorize]
        public  ActionResult ChangeGoalStatus(EGoalStageImplementation status,int goalId)
        {
            var goal = Goals.GetGoal(goalId);
          
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                

                if (goal.User == userId)
                {
                    new Thread(() =>
                    { Goals.ChangeGoalStatus(status, goalId); }).Start();
                    
                    
                    goal.StageImplementation = status;
                }
               

           
            return PartialView("Profile/Goal",goal);
        }


        public IActionResult Error404()
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