using DAL.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using _1_Authentication_Authorization.ViewModel;

namespace _1_Authentication_Authorization.Component
{
    public class NavbarViewComponent : ViewComponent
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public NavbarViewComponent(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var navbarViewModel = new NavbarViewModel();

            if (signInManager.IsSignedIn((ClaimsPrincipal)User))
            {
                var user = await userManager.GetUserAsync((ClaimsPrincipal)User);
                var profilePicture = user.profileImage;

                navbarViewModel.IsSignedIn = true;
                navbarViewModel.ProfilePicture = profilePicture;
                navbarViewModel.UserName = User.Identity.Name;

                var isInRole = await userManager.IsInRoleAsync(user, "Admin"); // Replace "Admin" with the desired role name
                navbarViewModel.IsAdmin = isInRole;
            }

            return View("Navbar", navbarViewModel);
        }
    }
}
