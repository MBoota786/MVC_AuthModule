using _3_Auth_Module_AtoZ.ViewModel;
using DAL.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _3_Auth_Module_AtoZ.Component.IdentityProfileComponent
{
    public class ProfileViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public ProfileViewComponent(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var model = new ProfileViewModel
            {
                UserName = user.UserName,
                Email = user.Email
                // Add any additional profile properties you want to display
            };
            return View("/Views/Shared/Components/IdentityProfileComponent/Profile/Profile.cshtml", model);
        }


    }
}
