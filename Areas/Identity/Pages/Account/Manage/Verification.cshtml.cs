using System.Threading.Tasks;
using LifeGoals.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LifeGoals.Areas.Identity.Pages.Account.Manage
{
    public class Verification : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<Verification> _logger;

        public Verification(
            UserManager<ApplicationUser> userManager,
            ILogger<Verification> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
         
            return Page();
        }
    }
}