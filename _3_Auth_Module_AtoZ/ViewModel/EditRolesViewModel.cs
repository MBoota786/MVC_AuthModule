using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace _3_Auth_Module_AtoZ.ViewModel
{
    //using in  Roles Assing To user
    public class EditRolesViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<RoleViewModel> AllRoles { get; set; }
        public List<string> SelectedRoles { get; set; }
    }
}
