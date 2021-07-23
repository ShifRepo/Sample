using System;
using System.Collections.Generic;
using System.Text;
using FastBite.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FastBite.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
         public DbSet<Category> Category{get;set;}
        public DbSet<SubCategory> SubCategory{get;set;}
         public DbSet<ApplicationUser> ApplicationUser{get;set;}
      
    }
}
