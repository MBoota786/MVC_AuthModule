using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Data
{
    //________________________ 1. Add Custom Column in ---> IdentityUser Table _________________________________
    //________________________ 2. Create New Model ==> Inharite With  (IdentityUser)_________________
    //________________________ 3. Find All References  of (IdentityUser) --> Replace with ==> ApplicationUser___________________
    //________________________ 4. Add Properties __________________________
    //________________________ 5. Add ApplicationUser Model ===> in  IdentityUser Generic ___________________
    //________________________ 6. Add migration --> Update-database _______________________
    //________________________ 7. Add Same Properteis --> in ---> SignUp Model _____________________
    public class ApplicationUser:IdentityUser
    {
        public string Country { get; set; }
        public string profileImage { get; set; }
    }
}
