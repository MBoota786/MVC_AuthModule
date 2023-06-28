using DAL.Data;
using DML._1_clsAuthentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.IO;
using System.Threading.Tasks;

namespace _3_Authentication_Authorization_Other_Project.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {


        //_________________________ 2nd _____________________
        private readonly UserManager<ApplicationUser> identityUser;
        private readonly SignInManager<ApplicationUser> identityManager;
        private readonly RoleManager<IdentityRole> roleManager;

        //_____ for Image ____
        private readonly IWebHostEnvironment iWebHost;

        public AccountController(UserManager<ApplicationUser> identityUser , SignInManager<ApplicationUser> identityManager , IWebHostEnvironment iweb, RoleManager<IdentityRole> roleManager)
        {
            this.identityUser = identityUser;
            this.identityManager = identityManager;
            this.iWebHost = iweb;
            //____ adding role ___
            this.roleManager = roleManager;
        }


        //__________________________ 1st ______________________________
        public IActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signup(clsSignUpAuthentication signUp)
        {
            if (ModelState.IsValid)
            {
                // Check if the email already exists
                var checkUser = await identityUser.FindByEmailAsync(signUp.Email);
                if (checkUser != null)
                {
                    ViewBag.email = "Email Already Exists";
                    return View(signUp);
                }

                var proImage = "images/plache.png";
                if (signUp.iImage != null)
                {
                    proImage = "images/ProfileImage/";
                    proImage += Guid.NewGuid().ToString() + "_" + signUp.iImage.FileName;
                    var serverFolder = Path.Combine(iWebHost.WebRootPath, proImage);

                    using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                    {
                        await signUp.iImage.CopyToAsync(fileMode);
                    }
                }

                var appUser = new ApplicationUser
                {
                    UserName = signUp.Email,
                    Email = signUp.Email,
                    Country = signUp.Country,
                    profileImage = proImage
                };

                var result = await identityUser.CreateAsync(appUser, signUp.Password);

                if (result.Succeeded)
                {
                    // Check if the "User" role exists
                    var roleExists = await roleManager.RoleExistsAsync("User");
                    if (!roleExists)
                    {
                        // If "User" role doesn't exist, create it
                        await roleManager.CreateAsync(new IdentityRole("User"));
                    }

                    // Assign the "User" role to the newly registered user
                    await identityUser.AddToRoleAsync(appUser, "User");

                    await identityManager.SignInAsync(appUser, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View();
        }




        //_________________________ 4th  Logout ___________________
        public async Task<IActionResult> Logout()
        {
            await identityManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        //________________________ 5th SignIn _____________________________
        public IActionResult Signin(string url)
        {
            //if ( = ulr)
            //{

            //}
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Signin(clsSignInAuthentication signIn)
        {
            if (ModelState.IsValid)
            {
                var result = await identityManager.PasswordSignInAsync(signIn.Email, signIn.Password, signIn.isRemember, false);//isPersistent: true , false /*Accunt Lock krnaa Wrong Password par*/);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else //if wrong Password , Email 
                {
                    //___ Eror ____
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }
            return View();
        }

        //______________________ Not Fund Page ________________________
        public IActionResult notFound()
        {
            return View();
        }

    }
}
