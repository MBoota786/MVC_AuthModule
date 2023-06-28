using System.ComponentModel.DataAnnotations;

namespace DML._1_clsAuthentication
{
    public class clsSignInAuthentication
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        //____ Login Rakhnaa ha yaa nhin _____ User ke  Choice ha kaa ===> Login Rkhaa yaa na ===> Required nhin lgain ga
        public bool isRemember { get; set; }

    }
}
