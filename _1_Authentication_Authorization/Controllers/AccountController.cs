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

        //_____ for Image ____
        private readonly IWebHostEnvironment iWebHost;

        public AccountController(UserManager<ApplicationUser> identityUser , SignInManager<ApplicationUser> identityManager , IWebHostEnvironment iweb)
        {
            this.identityUser = identityUser;
            this.identityManager = identityManager;
            this.iWebHost = iweb;
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
                //_____ Check Email _________ (by Default hotaa ha Validate)
                var checkUser = await identityUser.FindByEmailAsync(signUp.Email);
                if (checkUser == null)
                {
                    ViewBag.email = "No Match";
                }
                else
                {
                    ViewBag.email = "Email Aready Exist";
                    return View(signUp);
                }


                var proImage = "images/plache.png";
                if (signUp.iImage != null)
                {
                    proImage = "images/ProfileImage/";
                    proImage += Guid.NewGuid().ToString() + "_" + signUp.iImage.FileName;
                    var serverFolder = Path.Combine(iWebHost.WebRootPath, proImage);  // /images/ProfileImages/image.jpg
                    using (var fileMode = new FileStream(serverFolder, FileMode.Create))  // /images/ProfileImages/image.jpg , fileMode.create
                    {
                        await signUp.iImage.CopyToAsync(fileMode);
                    }
                }

                var appUer = new ApplicationUser
                {
                    UserName = signUp.Email,
                    Email = signUp.Email,
                    Country = signUp.Country,
                    profileImage = proImage
                };

                var result = await identityUser.CreateAsync(appUer, signUp.Password);


                if (result.Succeeded)
                {
                    await identityManager.SignInAsync(appUer, isPersistent: false);
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


        //________________________ Image Upload ________________________________
        //public async Task<IActionResult> UserProfilePicMethod(string? id)
        //{
        //    var user = await identityUser.FindByIdAsync(id);
        //    var profilPicName = user.profileImage;
        //    if (profilPicName != null)
        //    {
        //        string profilePicPath = Path.Combine(iweb.WebRootPath, "images", profilPicName);
        //        //return the image file path
        //        return PhysicalFile(profilePicPath, "image/jpg");
        //    }
        //    //If no image exists return a placeholder image
        //    var profilePicPathNull = Path.Combine(iweb.WebRootPath, "images", "plache.png");
        //    return PhysicalFile(profilePicPathNull, "image/jpg");
        //}


    }
}
