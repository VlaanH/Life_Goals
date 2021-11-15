using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeGoals.Areas.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using LifeGoals.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace LifeGoals
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
    
            services.AddRecaptcha(new RecaptchaOptions
            {
                SiteKey = "6Lc2u0IaAAAAAOjtY1GNGXNcdDwWiIknTrfvJ3W2",
                SecretKey = "6Lc2u0IaAAAAAM8AXiZG5N8AKHxB4PL1B52bSOzf",
                ValidationMessage = "Are you a robot?"
            });
            services.AddDbContext<Models.ApplicationDbContext>(options =>
                options.UseSqlite(
                    
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>(
                    options =>
                    {
                        options.SignIn.RequireConfirmedAccount = false;
                        options.SignIn.RequireConfirmedEmail = false;
                        options.User.RequireUniqueEmail = true;
                        options.Password.RequiredLength = 7;
                        options.Password.RequireDigit = false;
                        options.Password.RequiredUniqueChars = 0;
                        options.Password.RequireUppercase = false;
                    })
                .AddEntityFrameworkStores<Models.ApplicationDbContext>();
            
            services.AddMvc();

            services.AddControllersWithViews();
        }

        
        
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
              
                
                app.UseHsts();
            }
            
            app.UseStatusCodePagesWithReExecute("/Home/Error404");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            
            
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Profile}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}