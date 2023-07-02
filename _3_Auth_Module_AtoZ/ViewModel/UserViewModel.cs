using System.Collections.Generic;

namespace _3_Auth_Module_AtoZ.ViewModel
{
    public class UserListViewModel
    {
        public List<UserViewModel> Users { get; set; } = new List<UserViewModel>();
    }
    public class UserViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
        public List<ClaimViewModel> Claims { get; set; }
    }
}
