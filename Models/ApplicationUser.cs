using System;
using System.Dynamic;
using LifeGoals.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LifeGoals.Models
{
    
   
    public class AppUser
    {
        public int Id { get; set; }
        public string Address { get; set; }
        
        public string Nickname { get; set; }
        public string Description { get; set; }
        
        public string Background { get; set; }
        
        public string Imag { get; set; }
    }
    
    
    
   
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base() { }
 
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        public DbSet<GoalObjects> Goals{ get; set; }
        public DbSet<AppUser> Users{ get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        
            optionsBuilder.UseSqlite("Data Source=app.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            base.OnModelCreating(builder);
        }
    
    
    }
}
