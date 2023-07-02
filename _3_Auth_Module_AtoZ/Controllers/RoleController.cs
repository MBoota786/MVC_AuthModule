using _3_Auth_Module_AtoZ.ViewModel;
using DAL.Data;
using DML._3_Auth_Module;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace _3_Auth_Module_AtoZ.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly dbContext context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public RoleController(RoleManager<IdentityRole> roleManager
                    ,UserManager<ApplicationUser> userManager
                    , dbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            this.context = context;
        }

        /*_________________________ Master View _______________________*/
        public async Task<IActionResult> UserList()
        {
            var users = await _userManager.Users.ToListAsync();
            var viewModel = new List<UserViewModel>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var claims = await _userManager.GetClaimsAsync(user);

                var userViewModel = new UserViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    Roles = roles.ToList(),
                    Claims = claims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value }).ToList()
                };

                viewModel.Add(userViewModel);
            }

            return View(viewModel);
        }


        //_______________ Manage Roles _______________________
        #region Assign_Roles
        [HttpGet]
        public async Task<IActionResult> EditRolesAssign(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var allRoles = _roleManager.Roles.Select(r => new RoleViewModel { RoleName = r.Name }).ToList();

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in allRoles)
            {
                role.IsSelected = userRoles.Contains(role.RoleName);
            }

            var viewModel = new EditRolesViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                AllRoles = allRoles
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRolesAssign(EditRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var selectedRoles = model.SelectedRoles ?? new List<string>();
            var userRoles = await _userManager.GetRolesAsync(user);

            var rolesToAdd = selectedRoles.Except(userRoles);
            var rolesToRemove = userRoles.Except(selectedRoles);

            await _userManager.AddToRolesAsync(user, rolesToAdd);
            await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

            return RedirectToAction("UserList");
        }

        #endregion

        /*_______________ Roles CRUD ______________________*/
        #region Assign_Roles
        public IActionResult Roles()
        {
            var roles = _roleManager.Roles.OrderBy(x=>x.Name).ToList();
            return View(roles);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = model.RoleName };
                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Roles"); // Redirect to the desired page
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound();
            }

            var model = new EditRoleViewModel { RoleId = role.Id, RoleName = role.Name };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.RoleId);
                if (role == null)
                {
                    return NotFound();
                }

                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Roles"); // Redirect to the desired page
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        
        public async Task<IActionResult> DeleteRole(string roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);

            if (result.Succeeded)
            {
                return RedirectToAction("Roles"); // Redirect to the desired page
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return View(roleId);
        }
        #endregion

        //_______________ Manage Claims _______________________
        #region Manage_Claims

        //__________ 1 Static Claims _____________
        #region Static Claims
        //1. create ClaimStore Class    -- to Store Claim  staticly -- in DML
        //2. dd UserClaimsViewModel  to get ---> userId , staticClaims (userClaims)
        //3. In IdentityDatabase ---> Assign Claims Stored in  AspNetUserClaims tables (id,UserId,ClaimType,ClaimValue)
        [HttpGet]
        public async Task<IActionResult> ManageUserClaims(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            // UserManager service GetClaimsAsync method gets all the current claims of the user
            var existingUserClaims = await _userManager.GetClaimsAsync(user);

            var model = new UserClaimsViewModel
            {
                UserId = userId,
                UserName = user.UserName
            };

            // Loop through each claim we have in our application
            foreach (Claim claim in ClaimsStore.AllClaims)  //3 bar loop chlaa gaa
            {
                UserClaim userClaim = new UserClaim
                {
                    ClaimType = claim.Type
                };

                // If the user has the claim, set IsSelected property to true, so the checkbox
                // next to the claim is checked on the UI
                if (existingUserClaims.Any(c => c.Type == claim.Type))
                {
                    userClaim.IsSelected = true;
                }

                model.Cliams.Add(userClaim); //1st list dd , 2nd list ,  3rd list
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserClaims(UserClaimsViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.UserId} cannot be found";
                return View("NotFound");
            }

            // Get all the user existing claims and delete them
            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user, claims);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing claims");
                return View(model);
            }

            // Add all the claims that are selected on the UI
            result = await _userManager.AddClaimsAsync(user,
                model.Cliams.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType)));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected claims to user");
                return View(model);
            }

            return RedirectToAction("UserList");

        }

        #endregion

        //__________ 2 Database Claims _____________
        #region Database Claims
        //Create ClaimModel and Add to Database
        //Add some  Claims in Database Table
        //then the others Step will be same as Above
        [HttpGet]
        public async Task<IActionResult> ManageUserClaimsDb(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return View("NotFound");
            }

            // UserManager service GetClaimsAsync method gets all the current claims of the user
            var existingUserClaims = await _userManager.GetClaimsAsync(user);

            var model = new UserClaimsViewModelDb
            {
                UserId = userId,
                UserName = user.UserName
            };

            // Loop through each claim we have in our application
            foreach (var claim in context.myClaims)  //3 bar loop chlaa gaa
            {
                UserClaimDb userClaim = new UserClaimDb
                {
                    ClaimType = claim.type
                };

                // If the user has the claim, set IsSelected property to true, so the checkbox
                // next to the claim is checked on the UI
                if (existingUserClaims.Any(c => c.Type == claim.type))
                {
                    userClaim.IsSelected = true;
                }

                model.Cliams.Add(userClaim); //1st list dd , 2nd list ,  3rd list
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserClaimsDb(UserClaimsViewModelDb model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.UserId} cannot be found";
                return View("NotFound");
            }

            // Get all the user existing claims and delete them
            var claims = await _userManager.GetClaimsAsync(user);
            var result = await _userManager.RemoveClaimsAsync(user, claims);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing claims");
                return View(model);
            }

            // Add all the claims that are selected on the UI
            result = await _userManager.AddClaimsAsync(user,
                model.Cliams.Where(c => c.IsSelected).Select(c => new Claim(c.ClaimType, c.ClaimType)));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected claims to user");
                return View(model);
            }

            return RedirectToAction("UserList");
        }




        /*
        [HttpGet]
        public async Task<IActionResult> EditClaimAssign(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            var allClaims = await _userManager.GetClaimsAsync(user);

            var viewModel = new EditClaimViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                AllClaims = allClaims.Select(c => new ClaimViewModel { Type = c.Type, Value = c.Value }).ToList(),
                SelectedClaims = new List<ClaimViewModel>()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClaimAssign(EditClaimViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var selectedClaimTypes = model.SelectedClaims?.Select(c => c.Type) ?? new List<string>();
            var existingClaims = await _userManager.GetClaimsAsync(user);

            var claimsToAdd = model.SelectedClaims
                .Where(c => !existingClaims.Any(ec => ec.Type == c.Type && ec.Value == c.Value))
                .Select(c => new Claim(c.Type, c.Value));
            var claimsToRemove = existingClaims.Where(ec => !model.SelectedClaims.Any(c => c.Type == ec.Type && c.Value == ec.Value)).ToList();


            await _userManager.AddClaimsAsync(user, claimsToAdd);
            await _userManager.RemoveClaimsAsync(user, claimsToRemove);

            return RedirectToAction("UserList");
        }
        */
        #endregion

        #endregion

        //_______________ Claims CRUD ___________________________
        #region Claims_CRUD
        public IActionResult Claims()
        {
            var list = context.myClaims.ToList();
            return View(list);
        }

        public IActionResult CreateClaim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateClaim(myClaims model)
        {
            context.myClaims.Add(model);
            context.SaveChanges();
            return RedirectToAction("Claims");
        }

        public IActionResult EditClaim(int id)
        {
            var selectedRecord = context.myClaims.Find(id);
            return View(selectedRecord);
        }
        [HttpPost]
        public IActionResult EditClaim(myClaims model)
        {
            context.myClaims.Update(model);
            context.SaveChanges();
            return RedirectToAction("Claims");
        }

        public IActionResult DeleteClaim(int id)
        {
            var selectedRecord = context.myClaims.Find(id);
            context.myClaims.Remove(selectedRecord);
            context.SaveChanges();
            return RedirectToAction("Claims");
        }
        #endregion

    }
}

