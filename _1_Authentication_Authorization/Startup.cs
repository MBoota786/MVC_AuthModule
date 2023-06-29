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
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _3_Authentication_Authorization_Other_Project
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


            //__________________ Authentication ___________________
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                //_______________________"Identity configuration options" _______________________
                // User settings
                options.User.AllowedUserNameCharacters = "";
                options.User.RequireUniqueEmail = true;

                // Password settings
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;

                // SignIn settings
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;

                // Token settings
                options.Tokens.AuthenticatorTokenProvider = TokenOptions.DefaultAuthenticatorProvider;
                //options.Tokens.ChangeEmailTokenProvider = TokenOptions.DefaultEmailChangeTokenProvider;
                options.Tokens.ChangePhoneNumberTokenProvider = TokenOptions.DefaultPhoneProvider;
                options.Tokens.EmailConfirmationTokenProvider = TokenOptions.DefaultEmailProvider;
                options.Tokens.PasswordResetTokenProvider = TokenOptions.DefaultProvider;

                // Other settings
                options.Stores.MaxLengthForKeys = 128;
                options.ClaimsIdentity.UserNameClaimType = ClaimTypes.Name;
                options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier;
                options.ClaimsIdentity.RoleClaimType = ClaimTypes.Role;
            }).AddEntityFrameworkStores<dbContext>();

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
            //services.AddControllersWithViews(config =>    Same Work
            services.AddControllersWithViews(config =>
            {
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            }).AddRazorRuntimeCompilation();


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
