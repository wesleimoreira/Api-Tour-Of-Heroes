using System.ComponentModel.DataAnnotations;

namespace Api_Tour_Of_Heroes_Application.ViewModels
{
    public  class UserViewModel
    { 
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The hero userName is mandatory!")]
        [MinLength(3, ErrorMessage = "The userName must contain at least 3 characters!")]
        [MaxLength(200, ErrorMessage = "the userName must contain a maximum of 200 characters!")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "The hero Password is mandatory!")]
        [MinLength(3, ErrorMessage = "The Password must contain at least 3 characters!")]
        [MaxLength(10, ErrorMessage = "the Password must contain a maximum of 10 characters!")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "The Role name is mandatory!")]
        [MinLength(3, ErrorMessage = "The Role must contain at least 3 characters!")]
        [MaxLength(100, ErrorMessage = "the Role must contain a maximum of 100 characters!")]
        public string? Role { get; set; }
    }
}
