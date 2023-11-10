using _3_Auth_Module_AtoZ.Component.IdentityProfileComponent;
using _3_Auth_Module_AtoZ.Services;
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
            services.AddScoped<ProfileViewComponent>();



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
            services.AddDbContext<dbContext>(o =>
            {
                var connectionString = Configuration.GetConnectionString("MyDbConnection");
                o.UseSqlServer(connectionString);
            });


            //__________________________ Token ________________________________
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(2); // Set the token lifespan as desired
            });

            //__________________ Authentication ___________________
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // Configure the Two-Factor Authentication token provider
                options.Tokens.ProviderMap["Default"] = new TokenProviderDescriptor(typeof(DataProtectorTokenProvider<ApplicationUser>));
            })
            .AddEntityFrameworkStores<dbContext>()
            .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider);

            
            

            //__________________ Cookie Pages (login,logout,..) ___________________________
            //services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Signin/");
            services.ConfigureApplicationCookie(options =>
            {
                //_______________________"Identity configuration options" _______________________
                // Cookie settings
                //options.Cookie.Name = ".AspNetCore.Identity.Application";
                //options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(2);//FromDays(14); m
                //options.LoginPath = "/Account/Signin/";
                //options.LogoutPath = "/Account/Logout/";
                options.AccessDeniedPath = "/Account/notFound/";
                //options.SlidingExpiration = true;
            });



            //___________________ Email Services ________________________
            services.AddTransient<EmailService>();


            services.AddAuthorization();
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
