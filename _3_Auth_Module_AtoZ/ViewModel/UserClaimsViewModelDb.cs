using System.Collections.Generic;
using System.Security.Claims;

namespace _3_Auth_Module_AtoZ.ViewModel
{
    public class UserClaimsViewModelDb
    {
        public UserClaimsViewModelDb()
        {
            Cliams = new List<UserClaimDb>();
            AvailableClaims = new List<Claim>();
        }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<UserClaimDb> Cliams { get; set; }
        public List<Claim> AvailableClaims { get; set; }
    }


    public class UserClaimDb
    {
        public string ClaimType { get; set; }
        public bool IsSelected { get; set; }
    }
}
