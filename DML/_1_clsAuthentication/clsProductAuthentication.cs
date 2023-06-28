using System.ComponentModel.DataAnnotations;

namespace DML._1_clsAuthentication
{
    public class clsProductAuthentication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string price { get; set; }
    }
}
