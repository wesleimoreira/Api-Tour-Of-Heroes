using System.ComponentModel.DataAnnotations;

namespace Api_Tour_Of_Heroes_Application.ViewModels
{
    public class HeroViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "The hero name is mandatory!")]
        [MinLength(3, ErrorMessage = "The name must contain at least 3 characters!")]
        [MaxLength(200, ErrorMessage = "the name must contain a maximum of 200 characters!")]
        public string? Name { get; set; }
    }
}
