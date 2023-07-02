using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace _3_Auth_Module_AtoZ.ViewModel
{
    public class EditClaimViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<ClaimViewModel> AllClaims { get; set; }
        public List<ClaimViewModel> SelectedClaims { get; set; }
    }


}
