using DAL.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _3_Auth_Module_AtoZ
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
            //*******************  3. Globle Level Authorize  *******************
            //services.AddControllersWithViews(config =>    Same Work
            services.AddControllersWithViews(config =>
            {
                //var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                //config.Filters.Add(new AuthorizeFilter(policy));
            }).AddRazorRuntimeCompilation();


            //___________________ Connection_ 1 ___________________________
            //string con = "Server = SAQIB\\SAQIB;database = AuthenAuthorProjectDb;Trusted_Connection=true";
            //services.AddDbContext<dbContext>(o =>
            //{
            //    o.UseSqlServer(con);
            //});

            //___________________ Connection_ 2 ___________________________
            string con = "Server = SAQIB\\SAQIB;database = AuthenAuthorProjectDb;Trusted_Connection=true;MultipleActiveResultSets=true";
            services.AddDbContext<dbContext>(o =>
            {
                var connectionString = Configuration.GetConnectionString("MyDbConnection");
                o.UseSqlServer(connectionString);
            });



            //__________________ Authentication ___________________
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {}).AddEntityFrameworkStores<dbContext>();

            //__________________ Cookie Pages (login,logout,..) ___________________________
            //services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Signin/");
            services.ConfigureApplicationCookie(options =>
            {
                //_______________________"Identity configuration options" _______________________
                // Cookie settings
                //options.Cookie.Name = ".AspNetCore.Identity.Application";
                //options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromSeconds(60);//FromDays(14); m
                //options.LoginPath = "/Account/Signin/";
                //options.LogoutPath = "/Account/Logout/";
                options.AccessDeniedPath = "/Account/notFound/";
                //options.SlidingExpiration = true;
            });


            //___________________ Globel Level Authorization ________________________
            //services.AddAuthorization();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //________________ Authentication _________________
            app.UseAuthentication();

            //________________ Authorization _________________
            app.UseAuthorization();

            //________________ Configure method Not Found _________________
            app.UseStatusCodePagesWithReExecute("/Account/NotFound/{0}");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
