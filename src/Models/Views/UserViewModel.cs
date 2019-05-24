using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models.Views
{
    public class UserViewModel
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
