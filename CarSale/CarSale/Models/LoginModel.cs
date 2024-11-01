using System.ComponentModel.DataAnnotations;

namespace CarSale.Models
{
    public class LoginModel
    {
        [Required]
        public int UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
