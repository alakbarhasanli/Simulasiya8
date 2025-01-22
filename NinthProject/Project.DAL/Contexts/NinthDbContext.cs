using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Contexts
{
    public class NinthDbContext:IdentityDbContext<IdentityUser,IdentityRole,string>
    {
        public DbSet<Treatment> treatments { get; set; }
        public DbSet<Doctor> doctors { get; set; }
        public NinthDbContext(DbContextOptions opt):base(opt)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<IdentityRole>().HasData(
             new IdentityRole { Id = "c336f3ac-c27d-4a89-bdf2-c278486f8598", Name = "admin", NormalizedName = "ADMIN" },
             new IdentityRole { Id = "62adfc41-1919-468e-93a7-d934cad9864e", Name = "user", NormalizedName = "user" }

             );
            IdentityUser admin = new()
            {
                Id = "a3e3b4e5-9562-498a-b821-ba1cde7aae8d",
                UserName = "admin",
                NormalizedUserName = "ADMIN"
            };
            PasswordHasher<IdentityUser> hash = new();
            admin.PasswordHash = hash.HashPassword(admin, "admin123!");
            builder.Entity<IdentityUser>().HasData(admin);
            builder.Entity<IdentityUserRole<string>>().HasData
                (
                new IdentityUserRole<string> {RoleId= "c336f3ac-c27d-4a89-bdf2-c278486f8598",UserId=admin.Id }
                );
            base.OnModelCreating(builder);
        }
    }
}
