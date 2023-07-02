using System.Collections.Generic;

namespace _3_Auth_Module_AtoZ.ViewModel
{
    public class UserClaimsViewModel
    {
        public UserClaimsViewModel()
        {
            Cliams = new List<UserClaim>();
        }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<UserClaim> Cliams { get; set; }
    }
    public class UserClaim
    {
        public string ClaimType { get; set; }
        public bool IsSelected { get; set; }
    }
}
