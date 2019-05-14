using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Models.Views
{
    public class UserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
