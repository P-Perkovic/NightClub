using System.ComponentModel.DataAnnotations;

namespace NightClub.API.Dtos.User
{
    public class UserAddDto
    {
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(255, ErrorMessage = "The field max length is 255 characters")]
        public string Name { get; set; }

        public string Nickname { get; set; }

        [Required(ErrorMessage = "The field is required")]
        [StringLength(255, ErrorMessage = "The field max length is 255 characters")]
        public string Email { get; set; }
    }
}
