using DML._1_clsAuthentication;
using DML._3_Auth_Module;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class dbContext:IdentityDbContext<ApplicationUser>
    {
        public dbContext(DbContextOptions<dbContext> o):base(o)
        {

        }
        //_________________ 1 Authentication ____________________
        //ApplicationUser  automatically done at backend
        public DbSet<clsProductAuthentication> clProductsAuthentication { get; set; }

        //_________________ 3. AuthModule ________________________
        public DbSet<myClaims> myClaims { get; set; }



    }
}
